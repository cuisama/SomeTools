using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HjDictClient
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 多重起動防止
            //string processName = Process.GetCurrentProcess().ProcessName;
            //if (Process.GetProcessesByName(processName).Length > 1)

            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Init();
                Application.Run(new Main());
            }
            catch (Exception ex)
            {
                //Util.Cursor = Cursors.Default;
                string str = GetExceptionMsg(ex, string.Empty);
                MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Init()
        {
            if (File.Exists(Para.LOG_PATH))
            {
                //File.Delete(Para.LOG_PATH);
            }
            FileStream fs = File.Create(Para.LOG_PATH);
            fs.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="backStr"></param>
        /// <returns></returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("******************异常**************************");
            sb.AppendLine("「出现时间」：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("「异常类型」：" + ex.GetType().Name);
                sb.AppendLine("「异常信息」：" + ex.Message);
                sb.AppendLine("「堆栈信息」：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("「未处理的异常」：" + backStr);
            }
            sb.AppendLine("************************************************");
            return sb.ToString();
        }
    }
}
