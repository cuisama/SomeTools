
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompUse
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void WriteFile(string fileName, string format, params object[] args)
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
