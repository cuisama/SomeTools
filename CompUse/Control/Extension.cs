using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompUse
{
    public static partial class Util
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tex"></param>
        /// <returns></returns>
        public static string HostName(this TextBox tex)
        {
            //return @"8LB11L2-PC\SQLEXPRESS";
            return tex.Text.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DB"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Contains(this object[] DB, object value)
        {
            return ((IList)DB).Contains(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(this object obj)
        {
            return Int32.Parse(obj.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDate(this object obj)
        {
            return DateTime.ParseExact(obj.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToTime(this object obj)
        {
            if (obj == null || obj.ToString().Equals(""))
            {
                return "NULL";
            }
            return obj.ToString().Substring(0, 5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDateString(this object obj)
        {
            return obj.ToString().Replace("/", "").Substring(0, 8);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToImp(this string obj, int len, char c)
        {
            if (obj.Length < len)
            {
                return obj.PadLeft(len, c);
            }
            else
            {
                return obj.Substring(obj.Length - len);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iEnum"></param>
        /// <returns></returns>
        public static string[] ToArray(this IEnumerable<string> iEnum)
        {
            List<string> list = new List<string>();
            list.AddRange(iEnum);
            return list.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToStr(this DataTable dt)
        {

            string result = "\r\n";
            int ii = dt.Rows.Count;
            int jj = dt.Columns.Count;
            for (int j = 0; j < jj; j++)
            {
                result += dt.Columns[j].ColumnName + (j + 1 == jj ? "\r\n" : "\t");
            }
            for (int i = 0; i < ii; i++)
            {
                for(int j = 0; j < jj; j++)
                {
                    result += dt.Rows[i][j].ToString() + (j + 1 == jj ? "\r\n" : "\t");
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="arg"></param>
        public static void AddRow(this DataTable dt, params object[] arg)
        {
            DataRow dr = dt.NewRow();
            int length = Math.Min(arg.Length, dt.Columns.Count);
            for (int i = 0; i < length; i++)
            {
                dr[i] = arg[i];
            }
            dt.Rows.Add(dr);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="flag"></param>
        public static void Wink(this DataGridView dgv, bool flag)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, !flag, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="right"></param>
        /// <param name="down"></param>
        public static void LocMove(this Control control, int right, int down)
        {
            control.Location = new System.Drawing.Point(control.Location.X + right, control.Location.Y + down);
        }

    }
}
