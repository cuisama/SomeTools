using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReAVName
{
    class Program 
    {
        private static bool DB = true;
        private static string MODE = "NO_MUL";
        private static string Extension = ".mp4.avi.rmvb.mov.mpeg.wmv.flv.mkv.rm";

        static void Main(string[] args)
        {
            string path = string.Empty;
            if (args != null && args.Length > 0)
            {
                path = args[0];
            }
            else
            {
                path = Directory.GetCurrentDirectory();
            }
            if (MODE.Equals("MUL")) {
                string[] paths = { "D:\\temp", "G:\\tempm", "H:\\temp", "J:\\temp" };
                for(int i=0;i<paths.Length;i++)
                {
                    Exec(paths[i]);
                }
            }
            else
            {
                Exec(path);
            }

            Console.WriteLine("end");
            Console.ReadLine();
        }
        private static void Exec(String path)
        {
            string[] files = Directory.GetFiles(path, "*.*");
            Regex rgx = new Regex(pNum);
            string code = "";
            string title = "";
            bool NG = false;
            string msg = "";
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(i);
                NG = false;

                FileInfo file = new FileInfo(files[i]);
                if(!Extension.Contains(file.Extension.ToLower())) continue;

                code = rgx.Match(files[i]).Value;
                if (!string.IsNullOrEmpty(code))
                {
                    //Console.WriteLine(code);
                    int retryCount = 3;
                    Retry:
                    try
                    {
                        Video v = GetInfo(code);
                        if (v != null)
                        {
                            title = v.Name;
                            string sNewDirectory = Path.Combine(file.DirectoryName, "【" + title + file.Extension);
                            Console.WriteLine(sNewDirectory);
                            Directory.Move(files[i], sNewDirectory);
                        }

                    }
                    catch (Exception ex)
                    {
                        if (--retryCount > 0) goto Retry;
                        msg = ex.Message;
                        NG = true;
                    }

                }
                else
                {
                    NG = true;
                }

                if (NG == true)
                {
                    Console.WriteLine(files[i] + "    " + msg);
                }
            }
        }

        private static Video GetInfo(string code)
        {
            string url = string.Format("http://www.j20a.com/cn/vl_searchbyid.php?keyword={0}",code);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            string result = sr.ReadToEnd();
            return GetVideo(result);
        }

        private static Video GetVideo(string result)
        {
            string title = rgxTitle.Match(result).Value;
            if (title.Contains("识别码搜寻结果")) return null;
            string number = rgxNumber.Match(result).Value;
            string actor = rgxActor.Match(result).Value;
            string url = rgxUrl.Match(result).Value;
            string issueDate = rgxIssueDate.Match(result).Value;
            string duraction = rgxDuration.Match(result).Value;
            //string cateGory = rgxCategory.Match(result).Value;
            string director = rgxDirector.Match(result).Value;
            string maker = rgxMaker.Match(result).Value;
            string publisher = rgxPublisher.Match(result).Value;
            string image = rgxImage.Match(result).Value;

            Video video = new Video();
            video.Name = title.Replace("<title>", "").Replace("</title>", "").Replace(" - JAVLibrary", "");
            video.Number = new Regex(pNum).Match(number).Value;
            video.Actor = new Regex(">.*<").Match(actor).Value.Replace(">", "").Replace("<", "");
            video.Url = url.Replace("\"","").Replace("og:url content=","").Replace(">","");
            video.IssueDate = new Regex("\\d{4}-\\d{2}-\\d{2}").Match(issueDate).Value;
            video.Duration = new Regex("\\d{2,3}").Match(duraction).Value;
            MatchCollection mc = rgxCategory.Matches(result);
            foreach (Match m in mc)
            {
                video.Category += new Regex(">.*<").Match(m.Value).Value.Replace(">", "").Replace("<", "") + " ";
            }
            //video.Director = new Regex("text.*<").Match(director).Value.Replace(">", "").Replace("<", "").Replace("text\"", "");
            video.Director = new Regex(">.*<").Match(actor).Value.Replace(">", "").Replace("<", "");
            video.Maker = new Regex(">.*<").Match(maker).Value.Replace(">", "").Replace("<", "");
            video.Publisher = new Regex(">.*<").Match(publisher).Value.Replace(">", "").Replace("<", "");
            video.Image = new Regex("src=\".*?\"").Match(image).Value.Replace("src=", "").Replace("\"", "");
            if (DB == true)
            {
                InsertDB(video);
            } 

            return video;
        }

        private static int InsertDB(Video video)
        {
            int ret = 0;
            try
            {
                var cmd = new SqlCommand()
                {
                    Connection = GetCon(),
                    CommandText = "insert into WORKSET values(@Number, @Actor, @Name, @Url, @Duration, @IssueDate, @Category, @Director, @Maker, @Publisher, @Image)",
                    CommandTimeout = 10
                };
                cmd.Parameters.Add(new SqlParameter("@Number", video.Number));
                cmd.Parameters.Add(new SqlParameter("@Actor", video.Actor));
                cmd.Parameters.Add(new SqlParameter("@Name", video.Name));
                cmd.Parameters.Add(new SqlParameter("@Url", video.Url));
                cmd.Parameters.Add(new SqlParameter("@Duration", video.Duration));
                cmd.Parameters.Add(new SqlParameter("@IssueDate", video.IssueDate));
                cmd.Parameters.Add(new SqlParameter("@Category", video.Category));
                cmd.Parameters.Add(new SqlParameter("@Director", video.Director));
                cmd.Parameters.Add(new SqlParameter("@Maker", video.Maker));
                cmd.Parameters.Add(new SqlParameter("@Publisher", video.Publisher));
                cmd.Parameters.Add(new SqlParameter("@Image", video.Image));
                ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw;
                if(!ex.Message.Contains("PK_WORKSET") && con != null)
                {
                    con.Close();
                    con.Dispose();
                    con = null;
                }
            }
            return ret;
        }

        private static SqlConnection GetCon()
        {
            if(con == null)
            {
                string connectionString;
                connectionString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Integrated Security=false;",
                                                        "LAPTOP-R9PBI4EC\\SQLEXPRESS", "ENTSVR", "sa", "ncrsa_ora");
                con = new SqlConnection(connectionString);
                con.Open();
            }
            return con;
        }

        private static SqlConnection con = null;

        private static string pNum = "[A-Za-z]{3,4}-?[0-9]{3}";
        private static string pName = "<title>.*</title>";
        private static string pNumber = "video_id(.|\n)*?text.*<";
        private static string pActor = "vl_star\\.php\\?s=.*?<";
        private static string pUrl = "og:url.*>";
        private static string pIssueDate = "video_date(.|\n)*?text.*<";
        private static string pDuration = "video_length(.|\n)*?text.*<";
        private static string pCategory = "category tag.*?</a>";
        private static string pDirector = "vl_director\\.php\\?d=.*?<";//"video_director(.|\n)*?text.*<";
        private static string pMaker = "vl_maker\\.php\\?m=.*?<";
        private static string pPublisher = "vl_label\\.php\\?l=.*?<";
        private static string pImage = "video_jacket_img.*?width=";

        private static Regex rgxTitle = new Regex(pName);
        private static Regex rgxNumber = new Regex(pNumber);
        private static Regex rgxUrl = new Regex(pUrl);
        private static Regex rgxActor = new Regex(pActor);
        private static Regex rgxIssueDate = new Regex(pIssueDate, RegexOptions.ECMAScript);
        private static Regex rgxDuration = new Regex(pDuration);
        private static Regex rgxCategory = new Regex(pCategory);
        private static Regex rgxDirector = new Regex(pDirector);
        private static Regex rgxMaker = new Regex(pMaker);
        private static Regex rgxPublisher = new Regex(pPublisher);
        private static Regex rgxImage = new Regex(pImage);

    }
}
