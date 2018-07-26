using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjDictClient
{
    public class Para
    {

        public static string LOG_PATH = Directory.GetCurrentDirectory() + "\\HjDictClient.log";

        public static string AUDIO_PATH = Directory.GetCurrentDirectory() + "\\..\\..\\..\\HjDict\\words.en";

        public static bool MTAThread = true;

        public const int DB_SQL_COMMAND_TIME_OUT = 0;
        public static int DB_CONNECTION_TIMEOUT = 5000;

        public static string PCS_DBHOSTNAME = "LAPTOP-R9PBI4EC\\SQLEXPRESS";
        public static string PCS_DBNAME = "ENTSVR";
        public static string PCS_DBUSERID = "sa";
        public static string PCS_DBPASSWORD = "ncrsa_ora";
    }
}
