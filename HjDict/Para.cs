using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjDict
{
    public class Para
    {

        public static string LOG_PATH = Directory.GetCurrentDirectory() + "\\HjDict.log";
        public static bool MTAThread = true;

        public const int DB_SQL_COMMAND_TIME_OUT = 0;
        public static int DB_CONNECTION_TIMEOUT = 5000;

        public static string PCS_DBHOSTNAME = "8LB11L2-PC\\SQLEXPRESS";
        public static string PCS_DBNAME = "CTest";
        public static string PCS_DBUSERID = "sa";
        public static string PCS_DBPASSWORD = "ncrsa_ora";
    }
}
