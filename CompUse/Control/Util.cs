using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Resources;
using System.Diagnostics;
using System.Collections;
using System.Data.SqlClient;
using System.Threading;
using System.Reflection;
using CompUse.Properties;

namespace CompUse
{
    public static partial class Util
    {
        
        private static ResourceManager resourceManager = new ResourceManager(typeof(Resources));

        private static DataTable DtPosInfoCatch = null;


        
        private static void ShowByStoreCode(string dbHostName, string storeCode)
        {
            
        }
        
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MPosIp"></param>
        /// <param name="ComSPOSName"></param>
        /// <param name="dtSposInfo"></param>
        public static void InitComSPOSName(ComboBox ComSPOSName, ref DataTable dtSposInfo)
        {
            if (DtPosInfoCatch == null) return;
            dtSposInfo = DtPosInfoCatch.Copy();
            ComSPOSName.DataSource = dtSposInfo;
            ComSPOSName.ValueMember = "id";
            ComSPOSName.DisplayMember = "name";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public static void ShowMsg(string key)
        {
            MessageBox.Show(key, "システム", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        public static DialogResult ShowMsg(string key,string type)
        {
            switch(type)
            {
                case Para.XML:
                    MessageBox.Show(key, "Response", MessageBoxButtons.OK);
                    break;
                case Para.CONFIRM:
                    return MessageBox.Show(key, "提示", MessageBoxButtons.OKCancel);
            }
            return DialogResult.OK;
        }

        /// <summary>
        /// get msg from Resource.resx
        /// </summary>
        /// <param name="arg0"></param>
        /// <returns></returns>
        public static string RM(string arg0)
        {
            return resourceManager.GetString(arg0); 
        }

        /// <summary>
        /// get msg from Resource.resx
        /// </summary>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public static string RM(string arg0, string arg1)
        {
            return string.Format(resourceManager.GetString(arg0),resourceManager.GetString(arg1));
        }

            /// <summary>
            /// get msg from App.config
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public static string AppConf(string key)
            {
                return ConfigurationManager.AppSettings[key].Trim();
            }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TexIp"></param>
        /// <returns></returns>
        public static bool CheckIP(TextBox TexIp)
        {
            return CheckIP(TexIp.Text.Trim());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool CheckIP(string ipAddress)
        {
            Regex regex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            return (ipAddress != "" && regex.IsMatch(ipAddress.Trim())) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ImplicitStoreCode"></param>
        /// <returns></returns>
        public static bool CheckImpStoCode(string ImplicitStoreCode,int numDig)
        {
            Regex regex = new Regex(@"^\d{1,"+ numDig + "}$");
            return (ImplicitStoreCode != "" && regex.IsMatch(ImplicitStoreCode.Trim())) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ImplicitStoreCode"></param>
        /// <returns></returns>
        public static bool CheckPosCode(string posCode)
        {
            Regex regex = new Regex(@"^\d{1,13}$|^\d{1,8}$|^\d{1,7}$");
            return (posCode != "" && regex.IsMatch(posCode.Trim())) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BusinessDate"></param>
        /// <returns></returns>
        public static bool CheckBuss(string BusinessDate)
        {
            Regex regex = new Regex(@"^((((1[6-9]|[2-9]\d)\d{2})(0?[13578]|1[02])(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})(0?[13456789]|1[012])(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})0?2(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))0?229))$");
            return (BusinessDate != "" && regex.IsMatch(BusinessDate.Trim())) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BusinessDate"></param>
        /// <returns></returns>
        public static bool CheckDate(string date)
        {
            Regex regex = new Regex(@"^((((1[6-9]|[2-9]\d)\d{2})[/-]?(0?[13578]|1[02])[/-]?(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})[/-]?(0?[13456789]|1[012])[/-]?(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})[/-]?0?2[/-]?(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))[/-]?0?2[/-]?29[/-]?))$");
            return (date != "" && regex.IsMatch(date.Trim())) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quertSql"></param>
        /// <param name="bcpFileName"></param>
        /// <param name="dbHostName"></param>
        /// <param name="dbUserId"></param>
        /// <param name="dbPassword"></param>
        /// <returns></returns>
        public static string ExeBcpCommand(string quertSql, string bcpFileName, string dbHostName, string dbUserId, string dbPassword)
        {
            Process p = new Process();
            p.StartInfo.FileName = "CMD.EXE";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            string strOutput = null;
            try
            {
                p.Start();
                p.StandardInput.WriteLine(string.Format("BCP \"{0}\" QUERYOUT \"{1}.csv\" -c -S{2} -U{3} -P{4}",
                    quertSql, bcpFileName, dbHostName, dbUserId, dbPassword));
                p.StandardInput.WriteLine("EXIT");
                strOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception ex)
            {
                strOutput = ex.Message;
            }
            return strOutput;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            string result = string.Empty;
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                result += line;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strAbsoulteURI"></param>
        /// <returns></returns>
        public static string HttpGet(string HttpUrl)
        {
            Log.Write("HttpUrl:" + HttpUrl);
            //HttpUrl = "http://localhost:8086/WOApi/ItemInfoAPI/GetSystemInfo";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HttpUrl);
            request.UserAgent = Para.PROGRAME_NAME;
            request.Accept = "text/html, application/xhtml+xml, */*";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.ContentType = "text/html;charset=shift_jis";
            request.Timeout = Para.HTTP_REQUEST_TIMEOUT;
            request.Method = "GET";
            HttpWebResponse reponse = request.GetResponse() as HttpWebResponse;
            using (Stream s = reponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(s, Encoding.GetEncoding("shift_jis"));
                string xml = FormatXMl(reader.ReadToEnd());
                return xml;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sXml"></param>
        /// <returns></returns>
        private static string FormatXMl(string sXml)
        {
            return sXml;
            //XmlDocument xd = new XmlDocument();
            //xd.LoadXml(sXml);
            //XmlTextWriter xtw = null;
            //StringBuilder sb = new StringBuilder();
            //try
            //{
            //    xtw = new XmlTextWriter(new StringWriter(sb));
            //    xtw.Formatting = Formatting.Indented;
            //    xtw.Indentation = 1;
            //    xtw.IndentChar = '\t';
            //    xd.WriteTo(xtw);
            //}
            //finally
            //{
            //    if(xtw != null)
            //    {
            //        xtw.Close();
            //    }
            //}
            //return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbHostName">IPAdress</param>
        /// <param name="DBName">PCS_DB / MPOS_DB / MPOS_SSOL_DB</param>
        /// <param name="sqlName">*.sql</param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static DataTable GetDBTable(string dbHostName, string DBName,string sqlName,Dictionary<string, object> para)
        {

            using (DbManager db = new DbManager(dbHostName, DBName))
            {

                string filePath = Path.Combine(Para.LOCAL_PATH, Para.MK_TOOLS_CONF, "SQL", sqlName);
                if (File.Exists(filePath))
                {
                    string sql = Util.ReadFile(filePath);

                    DataTable tbl = db.CreateDataTable(sql, para);

                    if (tbl != null && tbl.Rows.Count > 0)
                    {
                        return tbl;
                    }
                    else
                    {
                        Util.ShowMsg(string.Format(Util.RM(Para.INFO_NO_DATA_SQLNAME),sqlName));
                        return null;
                    }
                }
                else
                {
                    Util.ShowMsg(string.Format(Util.RM(Para.ERR_FILE_NOT_FOUND), filePath));
                }
            }

            return null;
        }

        //public static Cursor Cursor = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        public static void BoforeEvent(Form f)
        {
            //Cursor = f.Cursor;
            //Cursor = Cursors.WaitCursor;
            f.Cursor = Cursors.WaitCursor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        public static void AfterEvent(Form f)
        {
            //Cursor = Cursors.Default;
            f.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void BoforeEvent(object sender, MouseEventArgs e)
        {
            (sender as Control).Parent.Cursor = Cursors.WaitCursor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void AfterEvent(object sender, MouseEventArgs e)
        {
            (sender as Control).Parent.Cursor = Cursors.Default;
            //Cursor = Cursors.Default;
            //f.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        public static void CatchException(Form f)
        {
            f.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="widths"></param>
        public static void SetGvWidth(DataGridView gv, int[] widths)
        {
            if (gv == null || gv.Columns.Count <= 0) return;
            for (int i = 0; i < widths.Length; i++)
            {
                gv.Columns[i].Width = widths[i];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBinText"></param>
        /// <returns></returns>
        public static byte[] GetByte(string sBinText)
        {
            if ((sBinText.Length % 2) != 0)
            {
                sBinText += " ";
            }
            byte[] bLabelContent = new byte[sBinText.Length / 2];
            string sTmp;
            for (int i = 0; i < bLabelContent.Length; i++)
            {
                sTmp = sBinText.Substring(i * 2, 2);
                bLabelContent[i] = Convert.ToByte(sTmp, 16);
            }
            return bLabelContent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteData"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ChangeBytestoStr(byte[] byteData, int startIndex, int length)
        {
            string strTemp = BitConverter.ToString(byteData, startIndex, length);
            char[] charTemp = strTemp.ToCharArray();

            string returnStr = "";
            for (int i = 0; i < charTemp.Length; i++)
            {
                if (charTemp[i] != '-')
                {
                    returnStr += charTemp[i];
                }
            }
            return returnStr;
        }


        
    }
}
