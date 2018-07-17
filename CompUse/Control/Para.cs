using System;
using System.IO;

namespace CompUse
{
    public static class Para
    {
        public static string PROGRAME_NAME = "MK_Tools";
        public static string MK_TOOLS_CONF = "MK_ToolsConf";
        public static string LOCAL_PATH = Directory.GetCurrentDirectory();
        public static string LOG_PATH = Path.Combine(LOCAL_PATH, "mktools.log");
        public static string EXEPLAN_LOG_PATH = Path.Combine(LOCAL_PATH, string.Format("exeplan_{0}.log", System.DateTime.Now.ToString("yyyyMMddhhmmss")));


        public static string PROC_SALEPRICE = "SalePriceControl";

        public static int HTTP_REQUEST_TIMEOUT = 18000;

        public static string EXECUTION_PLAN = "SalePriceControl";
        //"SET STATISTICS IO, TIME ON \n SET STATISTICS profile on \n";
        public static string SQL_EXECUTION_PLAN = "SET STATISTICS IO, TIME ON \n SET STATISTICS profile on \n select *from PRM_SYS_STOREBASE \n select* from MST_TERMINAL_TBL \n select* from PRM_SYS_HAISINTYPE";

        public const string PCS_AP = "PCS_AP";

        public const string PCS_DB = "PCS_DB";
        public const string MPOS_DB = "MPOS_DB";
        public const string MPOS_SSOL_DB = "MPOS_SSOL_DB";

        public const int DB_SQL_COMMAND_TIME_OUT = 0;
        
        /// <summary>
        /// POS_DB = POS_AP
        /// </summary>
        public const string POS_DB = "POS_DB";
        public const string XML = "XML";
        public const string CONFIRM = "CONFIRM";


        public static string PCS_DBHOSTNAME = "153.59.64.177";
        public static string PCS_DBNAME = "ENTSVR";
        public static string PCS_DBUSERID = "entsvr";
        public static string PCS_DBPASSWORD = "ncrsa_ora";



        public static int DB_CONNECTION_TIMEOUT = 3000;

        

        
        public static string TAG_DATE = "TAG_DATE";
        public static string TAG_TIME = "TAG_TIME";
        public static string TAG_PCSWEBAPIP = "TAG_PCSWEBAPIP";
        public static string TAG_PCSDBIP = "TAG_PCSDBIP";
        public static string TAG_PCSCOMM1IP = "TAG_PCSCOMM1IP";
        public static string TAG_PCSAPIP = "TAG_PCSAPIP";
        public static string TAG_MPOSIP = "TAG_MPOSIP";
        public static string TAG_SPOSIP = "TAG_SPOSIP";
        public static string TAG_POSIP = "TAG_POSIP";
        public static string TAG_IMPSTOCODE = "TAG_IMPSTOCODE";
        public static string TAG_BUSINESS_DATE = "TAG_BUSINESS_DATE";
        public static string TAG_POSCODE = "TAG_POSCODE";
        

        public static string INFO_NO_DATA = "INFO_NO_DATA";
        public static string INFO_NO_DATA_SQLNAME = "INFO_NO_DATA_SQLNAME";
        
        public static string INFO_DB_UPDATE_SUCC = "INFO_DB_UPDATE_SUCC";
        public static string INFO_DB_UPDATE_FAIL = "INFO_DB_UPDATE_FAIL";
        public static string INFO_CONFIRM = "INFO_CONFIRM";
        public static string ERR_FORMAT = "ERR_FORMAT";
        public static string ERR_FILE_NOT_FOUND = "ERR_FILE_NOT_FOUND";
        public static string ERR_FOLDER_NOT_FOUND = "ERR_FOLDER_NOT_FOUND";
        public static string WARN_PL_SELECT_RECORD = "WARN_PL_SELECT_RECORD";
        public static string INFO_FILE_COPY = "INFO_FILE_COPY";
        



    }
}
