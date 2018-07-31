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

        public static string PCS_DBHOSTNAME = @"8LB11L2-PC\SQLEXPRESS";
        public static string PCS_DBNAME = "ENTSVR";
        public static string PCS_DBUSERID = "sa";
        public static string PCS_DBPASSWORD = "ncrsa_ora";

        public static bool AUTO_PLAY = true;

        public static List<string> ValueEn = new List<string>() { "Value", "PronouncesUs", "Sample", "Phrase" };
        public static List<string> ValueJp = new List<string>() { "Value", "Pronounces", "Sample" };
        public static float CardFontSize = 9;
    }
}
