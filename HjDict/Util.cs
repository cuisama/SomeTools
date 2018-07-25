using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HjDict
{
    public static class Util
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
        /// <returns></returns>
        public static string Class(this string html, Tag tag, string clz)
        {
            return Regex.Match(html, string.Format("<{0} class=\"{1}\"(.|\n)*?{0}>", tag.ToString(), clz)).Value;
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
            return html.Trim();
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


        public static string FilterDB(this string html)
        {
            return html.Replace("'", "''");
        }

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
