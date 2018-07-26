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

namespace HjDictClient
{
    public static class Util
    {
        
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
