using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HjDictClient
{
    public static class Extendion
    {
        /// <summary>
        /// 根据class抽取div节点
        /// </summary>
        /// <param name="html"></param>
        /// <param name="clz"></param>
        /// <returns></returns>
        public static string Class(this string html,string clz)
        {
            return html.Class(Tag.div, clz);
        }

        /// <summary>
        /// 从html中抽取指定tag的指定class的节点
        /// </summary>
        /// <param name="html"></param>
        /// <param name="tag"></param>
        /// <param name="clz"></param>
        /// <returns></returns>(Regex.Match(html, string.Format("<div class=\"{0}\"((.|\n)*?<div(.|\n)*?</div>(.|\n)*?)*</div>", clz))).Value
        public static string Class(this string html, Tag tag, string clz)
        {
            return Regex.Match(html, string.Format("<{0} class=\"{1}\"(.|\n)*?{0}>", tag.ToString(), clz)).Value;
        }

        /// <summary>
        /// 不使用 正则有点问题
        /// </summary>
        /// <param name="html"></param>
        /// <param name="clz"></param>
        /// <returns></returns>
        public static string[] Pane(this string html, string clz)
        {
            MatchCollection mc = Regex.Matches(html, string.Format("<div class=\"{1}\"((.|\n)*?<div(.|\n)*?</div>(.|\n)*?)*?</div>", Tag.div.ToString(), clz));
            string[] pane = new string[mc.Count];
            int index = 0;
            foreach (Match m in mc)
            {
                pane[index++] = m.Value;
            }
            return pane;
        }

        /// <summary>
        /// 提取指定clz的div节点 （匹配对称的节点）
        /// </summary>
        /// <param name="html"></param>
        /// <param name="clz"></param>
        /// <returns></returns>
        public static string[] Match(this string html,string clz)
        {
            int count = Regex.Matches(html, string.Format("<div class=\"{0}\">", clz)).Count;
            string[] result = new string[count]; 

            string[] lines = html.Split('\n');
            bool go = false;
            int pi = 0;
            int index = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                if (index >= count) break;
                if (go)
                {
                    result[index] += lines[i] + "\n";
                    if (lines[i].Contains("<div"))
                    {
                        int t = (lines[i].Length - lines[i].Replace("<div", "").Length) / 4;
                        pi += t;
                    }
                    if (lines[i].Contains("</div>"))
                    {
                        int t = (lines[i].Length - lines[i].Replace("</div>", "").Length) / 6;
                        pi -= t;
                        if (pi < 0) pi = 0;
                    }
                    if (pi == 0)
                    {
                        pi = 0;
                        index++;
                        go = false;
                    }
                    continue;
                }

                if (lines[i].Contains(string.Format("<div class=\"{0}\">", clz)))
                {
                    pi = 1;
                    result[index] = lines[i] + "\n";
                    go = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 从一个节点中抽取属性
        /// </summary>
        /// <param name="document"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static string Attr(this string document, string attr)
        {
            return Regex.Match(document, attr + "=\".*?\"").Value.Replace(attr + "=", "").Replace("\"", "").Replace("'", "");
        }

        /// <summary>
        /// 把标签 换行符 空格都去掉
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string FilterHTML(this string html)
        {
            //return Regex.Replace(html, "(<.*?>)|\n", "").Replace(" ", "")
            //    .Replace("&#39;", "'").Replace("&quot;", "");

            html = Regex.Replace(html, "<.+?>|\n", "");
            html = Regex.Replace(html, "\\ +", " ");
            return html.Replace(FilterRule).Trim();
        }

        /// <summary>
        /// 把标签 空格都去掉 换行符留一个
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string FilterHTML_(this string html)
        {
            html = Regex.Replace(html, "<.+?>", "");
            html = Regex.Replace(html, "\\ +", " ");
            html = Regex.Replace(html, "((\\ )*\n(\\ )*)+", "\n");
            return html.Replace(FilterRule).Trim();
        }

        private static string[,] FilterRule = new string[4, 2] {
            { "&#39;", "'" }, { "&quot;", " " },
            { "&lt;", "<" }, { "&gt;" , ">" }
        };

        /// <summary>
        /// 用一个数组 替换另一个数组中的值
        /// </summary>
        /// <param name="html"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string Replace(this string html, string[,] rule)
        {

            for (int i = FilterRule.Length / 2 - 1; i >= 0; i--)
            {
                html = html.Replace(rule[i, 0], rule[i, 1]);
            }
            return html;
        }

        /// <summary>
        /// 将字段数据 转变成 可以插到数据库里的数据
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string FilterDB(this string html)
        {
            return html.Replace("'", "''");
        }

        /// <summary>
        /// 把整个单词数据 转化成 可插入数据库的
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static Word FilterDB(this Word word)
        {
            PropertyInfo[] PropertyList = word.GetType().GetProperties();
            foreach (PropertyInfo item in PropertyList)
            {
                string name = item.Name;
                string value = (string)item.GetValue(word, null);
                item.SetValue(word, value.FilterDB(), null);
            }
            return word;
        }

        /// <summary>
        /// 把单词转成datarow
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static DataRow ToDataRow(this Word word)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            PropertyInfo[] PropertyList = word.GetType().GetProperties();
            foreach (PropertyInfo item in PropertyList)
            {
                string name = item.Name;
                string value = (string)item.GetValue(word, null);
                dt.Columns.Add(name);
                dr[name] = value;
            }

            return dr;
        }

        public static DataRow[] ToDataRow(this Word[] words)
        {
            DataTable dt = new DataTable();
            DataRow[] drs = new DataRow[words != null ? words.Length : 0];
            for(int i = 0; i < drs.Length; i++)
            {
                drs[i] = words[i].ToDataRow();
                drs[i].Table.Columns.Add("RowNum");
                drs[i]["RowNum"] = i + 1;
            } 
            return drs;
        }


        public static void Wink(this Control con, bool flag)
        {
            Type conType = con.GetType();
            PropertyInfo pi = conType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(con, !flag, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="timeout"></param>
        public static void QuickOpen(this SqlConnection conn, int timeout)
        {
            Stopwatch sw = new Stopwatch();
            bool connectSuccess = false;

            Thread t = new Thread(delegate ()
            {
                try
                {
                    sw.Start();
                    conn.Open();
                    connectSuccess = true;
                }
                catch { }
            });

            t.IsBackground = true;
            t.Start();

            while (timeout > sw.ElapsedMilliseconds)
            {
                if (t.Join(100)) break;
            }

            if (!connectSuccess)
            {
                //ネットワーク パスが見つかりません。
                throw new Exception("SQL Server への接続を確立しているときにネットワーク関連またはインスタンス固有のエラーが発生しました。サーバーが見つからないかアクセスできません");
            }
        }

    }
}
