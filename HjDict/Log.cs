using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HjDict
{
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public static void Write(string str)
        {
            Write(str, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Write(string format, params object[] args)
        {
            WriteFile(Para.LOG_PATH, format, args);
        }

        static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void WriteFile(string fileName, string format, params object[] args)
        {
            if (Para.MTAThread)
            {
                try
                {
                    LogWriteLock.EnterWriteLock();
                    string logContent = string.Format("[{0}] {1}", Thread.CurrentThread.ManagedThreadId.ToString().PadLeft(5, '0'), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff  ")) + string.Format(format, args);
                    File.AppendAllText(fileName, logContent + "\r\n");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    LogWriteLock.ExitWriteLock();
                }
            }
            else
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(fileName, true);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff  ") + string.Format(format, args));
                    //Console.WriteLine(string.Format(format, args));
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
            
        }

    }


//    public static class Console
//    {
//        public static void WriteLine(string value)
//        {
//#if DEBUG
//            System.Console.WriteLine(value);
//#endif
//        }

//        public static void WriteLine(object value)
//        {
//#if DEBUG
//            System.Console.WriteLine(value);
//#endif
//        }

//        public static void WriteLine(string format, params object[] arg)
//        {
//#if DEBUG
//            System.Console.WriteLine(format, arg);
//#endif
//        }
//    }
}
