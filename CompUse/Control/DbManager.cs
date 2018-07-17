using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CompUse
{
    /// <summary>
    /// Microsoft社製のSQL Serverデータベースへのアクセス機能を提供します。
    /// </summary>
    /// <remarks>
    /// 本クラスは、IDisposableインターフェスを実装しており、
    /// トランザクションをかけた場合にでも、Dispose時に自動的に解除（ロールバック）する仕組みとしています。
    /// ですので、using句を利用して実装して下さい。
    /// </remarks>
    public class DbManager : IDisposable
    {

        #region Member

        private SqlConnection con = null;
        private SqlTransaction trn = null;

        #endregion

        #region Constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="hostName">ホスト名</param>
        /// <param name="dbName">データベース名</param>
        /// <param name="userId">ユーザＩＤ</param>
        /// <param name="password">パスワード</param>
        /// <remarks>
        /// 本クラスのインスタンス化時に、ＤＢへの接続を行っています。
        /// </remarks>
        /// <exception cref="DatabaseNotConnectException">
        /// 接続に失敗した場合にスローされます。
        /// </exception>
        public DbManager(string hostName, string dbName, string userId, string password)
        {
            Connect(hostName, dbName, userId, password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="DBName">PCS_DB / MPOS_DB / MPOS_SSOL_DB</param>
        public DbManager(string hostName, string DBName)
        {
            string dbName = string.Empty;
            string dbUserId = string.Empty;
            string dbPassword = string.Empty;
            switch (DBName)
            {
                case Para.PCS_DB:
                    dbName = Para.PCS_DBNAME;
                    dbUserId = Para.PCS_DBUSERID;
                    dbPassword = Para.PCS_DBPASSWORD;
                    break;
                default://use PCS_DB
                    dbName = Para.PCS_DBNAME;
                    dbUserId = Para.PCS_DBUSERID;
                    dbPassword = Para.PCS_DBPASSWORD;
                    break;

            }
            Connect(hostName, dbName, dbUserId, dbPassword);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// デストラクタ
        /// </summary>
        public void Dispose()
        {
            DisConnect();
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Property

        /// <summary>
        /// 使用中のコネクションオブジェクトを取得します。
        /// </summary>
        public SqlConnection Connection { get { return con; } }

        /// <summary>
        /// 使用中のトランザクションオブジェクトを取得します。
        /// </summary>
        public SqlTransaction Transaction { get { return trn; } }

        #endregion

        #region Method

        #region Public

        /// <summary>
        /// トランザクションを開始します。
        /// </summary>
        public void BeginTransaction()
        {
            trn = con.BeginTransaction();
        }

        /// <summary>
        /// トランザクションをコミットします。
        /// </summary>
        public void Commit()
        {
            trn.Commit();
            trn = null;
        }

        /// <summary>
        /// トランザクションをロールバックします。
        /// </summary>
        public void Rollback()
        {
            trn.Rollback();
            trn = null;
        }

        /// <summary>
        /// クエリーを実行します。
        /// </summary>
        /// <param name="sqlState">ＳＱＬ文</param>
        /// <returns>
        /// 影響を受けた行数を返します。
        /// </returns>
        /// <exception cref="ExecuteSqlException">
        /// 実行に失敗した場合にスローされます。
        /// </exception>
        public int ExeceteQuery(string sqlState)
        {
            return ExeceteQuery(sqlState, new Dictionary<string, object>());
        }

        /// <summary>
        /// クエリーを実行します。
        /// </summary>
        /// <param name="sqlState">ＳＱＬ文</param>
        /// <param name="parameters">ＳＱＬパラメータ（カラム名と値の組合せリストを指定。"@ID"と"00123"等々）</param>
        /// <remarks>
        /// 【注意】
        /// エラー時にＳＱＬ文をログ出力するとした場合、
        /// 個人情報に関わる名称などが、そのまま出力されてしまう恐れがありますので、
        /// そのようなケース時には、必ず本メソッドを利用してＳＱＬパラメータ渡しとして下さい。
        /// </remarks>
        /// <returns>
        /// 影響を受けた行数を返します。
        /// </returns>
        /// <exception cref="ExecuteSqlException">
        /// 実行に失敗した場合にスローされます。
        /// </exception>
        public int ExeceteQuery(string sqlState, Dictionary<string, object> parameters)
        {
            int ret = 0;
            try
            {
                var cmd = new SqlCommand()
                {
                    Connection = con,
                    Transaction = trn,
                    CommandText = sqlState,
                    CommandTimeout = Para.DB_SQL_COMMAND_TIME_OUT
                };
                foreach (var para in parameters)
                {
                    cmd.Parameters.Add(new SqlParameter(para.Key, para.Value));
                }
                OutputSQL(sqlState, parameters);
                ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            return ret;
        }

        /// <summary>
        /// 実行クエリーをDataTable形式で返します。
        /// </summary>
        /// <param name="sqlState">ＳＱＬ文</param>
        /// <returns>
        /// 取得結果をDataTableオブジェクト形式で返します。
        /// </returns>
        /// <exception cref="ExecuteSqlException">
        /// 実行に失敗した場合にスローされます。
        /// </exception>
        public DataTable CreateDataTable(string sqlState)
        {
            return CreateDataTable(sqlState, new Dictionary<string, object>());
        }

        /// <summary>
        /// 実行クエリーをDataTable形式で返します。
        /// </summary>
        /// <param name="sqlState">ＳＱＬ文</param>
        /// <param name="parameters">ＳＱＬパラメータ（カラム名と値の組合せリストを指定。"@ID"と"00123"等々）</param>
        /// <remarks>
        /// 【注意】
        /// エラー時にＳＱＬ文をログ出力するとした場合、
        /// 個人情報に関わる名称などが、そのまま出力されてしまう恐れがありますので、
        /// そのようなケース時には、必ず本メソッドを利用してＳＱＬパラメータ渡しとして下さい。
        /// </remarks>
        /// <returns>
        /// 取得結果をDataTableオブジェクト形式で返します。
        /// </returns>
        /// <exception cref="ExecuteSqlException">
        /// 実行に失敗した場合にスローされます。
        /// </exception>
        public DataTable CreateDataTable(string sqlState, Dictionary<string, object> parameters)
        {
            var dt = new DataTable();
            try
            {

                foreach (var para in parameters)
                {
                    if (para.Value.GetType() == typeof(DateTime))
                    {
                        sqlState = sqlState.Replace(para.Key, string.Format("convert(datetime,'{0}')", para.Value));
                    }
                    else if (para.Value.GetType() == typeof(int))
                    {
                        sqlState = sqlState.Replace(para.Key, para.Value.ToString());
                    }
                    else
                    {
                        sqlState = sqlState.Replace(para.Key, string.Format("'{0}'", para.Value));
                    }
                }

                var cmd = new SqlCommand()
                {
                    Connection = con,
                    CommandText = sqlState,
                    CommandTimeout = Para.DB_SQL_COMMAND_TIME_OUT
                };
                    OutputSQL(sqlState, new Dictionary<string, object>());

                using (var adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return dt;
        }

        public DataSet CreateDataSet(string sqlState, Dictionary<string, object> parameters)
        {
            var dt = new DataSet();
            try
            {
                sqlState = "SET STATISTICS IO, TIME ON \n SET STATISTICS profile on \n" + sqlState;
                var cmd = new SqlCommand()
                {
                    Connection = con,
                    CommandText = sqlState,
                    CommandTimeout = Para.DB_SQL_COMMAND_TIME_OUT
                };
                cmd.Connection.InfoMessage += new SqlInfoMessageEventHandler(conn_InfoMessage);
                OutputSQL(sqlState,new Dictionary<string, object>());

                SQLMessage = string.Empty;
                //method 1
                //foreach (var para in parameters)
                //{
                //    cmd.Parameters.Add(new SqlParameter(para.Key, para.Value));
                //}

                //method2
                //String name = "南 裕継";
                //parameters.Add("@CashierName", name);
                foreach (var para in parameters)
                {
                    if (para.Value.GetType() == typeof(string))
                    {
                        //string temp = System.Text.Encoding.UTF8.GetString(System.Text.Encoding.Default.GetBytes(para.Value.ToString()));
                        //cmd.Parameters.Add(new SqlParameter(para.Key, temp));

                        SqlParameter parameter = new SqlParameter(para.Key, SqlDbType.VarChar);
                        parameter.Value = para.Value.ToString();
                        cmd.Parameters.Add(parameter);
                    }
                    else
                    {
                        //SqlParameter parameter = new SqlParameter(para.Key, SqlDbType.DateTime);
                        //parameter.Value = para.Value.ToString();
                        //cmd.Parameters.Add(new SqlParameter(para.Key, parameter));
                        cmd.Parameters.Add(new SqlParameter(para.Key, para.Value));
                    }
                }
                
                //SqlParameter parameter2 = new SqlParameter("@CashierName", SqlDbType.VarChar);
                //parameter2.Value = "南 裕継";
                //cmd.Parameters.Add(parameter2);
            
                using (var adp = new SqlDataAdapter(cmd))
                {
                    
                    adp.Fill(dt);
                }
                Util.ShowMsg(SQLMessage);
                Log.Write(SQLMessage);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        public DataSet CreateDataSet(string sqlState)
        {
            var dt = new DataSet();
            try
            {
                var cmd = new SqlCommand()
                {
                    Connection = con,
                    CommandText = sqlState,
                    CommandTimeout = Para.DB_SQL_COMMAND_TIME_OUT
                };
                OutputSQL(sqlState, new Dictionary<string, object>());
                using (var adp = new SqlDataAdapter(cmd))
                {
                    adp.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        #endregion

        #region Private

        private static string SQLMessage = string.Empty;

        private static void conn_InfoMessage(Object sender, SqlInfoMessageEventArgs e)
        {
            SQLMessage += e.Message;
            //Util.ShowMsg(e.Message);
        }

        /// <summary>
        /// データベースに接続します。
        /// </summary>
        /// <param name="hostName">ホスト名</param>
        /// <param name="dbName">データベース名</param>
        /// <param name="userId">ユーザＩＤ</param>
        /// <param name="password">パスワード</param>
        /// <exception cref="DatabaseNotConnectException">
        /// 接続に失敗した場合にスローされます。
        /// </exception>
        private void Connect(string hostName, string dbName, string userId, string password)
        {
            string connectionString;

            try
            {
                connectionString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Integrated Security=false;",
                                                  hostName, dbName, userId, password);
                con = new SqlConnection(connectionString);
                //con.Open();
                con.QuickOpen(Para.DB_CONNECTION_TIMEOUT);
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// データベースを切断します。
        /// </summary>
        private void DisConnect()
        {
            if (trn != null)
            {
                trn.Rollback();
                trn.Dispose();
            }
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// 実行ＳＱＬ内容をデバッグ用ログへ出力します。
        /// </summary>
        /// <param name="sqlState">ＳＱＬ文</param>
        /// <param name="parameters">ＳＱＬパラメータ（カラム名と値の組合せリストを指定。"@ID"と"00123"等々）</param>
        private void OutputSQL(string sqlState, Dictionary<string, object> parameters)
        {
#if !DEBUG
            StreamWriter sw = null;
            try
            {
                string logFilePath = Path.Combine(Para.LOCAL_PATH, "mktools.log");
                if (!File.Exists(logFilePath))
                {
                    FileStream fs = File.Create(logFilePath);
                    fs.Close();
                }
                sw = new StreamWriter(logFilePath, true);
#endif
                string debugPara = null;

                foreach (var para in parameters)
                {
                    debugPara += String.Format("{0}={1}, ", para.Key, para.Value.ToString());
                }
#if DEBUG
                Console.WriteLine("SQL ==> " + sqlState);
#else
                sw.WriteLine(DateTime.Now.ToString() + "  SQL ==> " + sqlState);
#endif
                if (debugPara != null && !debugPara.Equals(string.Empty))
                {
                    debugPara = debugPara.Substring(0, debugPara.Length - 2);
#if DEBUG
                    Console.WriteLine("Parameter ==> " + debugPara);
#else
                    sw.WriteLine(DateTime.Now.ToString() + "  Parameter ==> " + debugPara);
#endif
                }
#if !DEBUG
            }
            finally
            {
                if(sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
#endif
        }

#endregion

#endregion

    }
}