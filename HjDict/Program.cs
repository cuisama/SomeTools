using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HjDict
{
    class Program
    {
        private static string LocalPath = Directory.GetCurrentDirectory() + "\\..\\..";

        private static string DealFile = "words.jp.txt";
        private static string folderName = DealFile.Substring(0, DealFile.LastIndexOf('.'));
        private static string resPath = Path.Combine(LocalPath, folderName);

        private static string EN_DICT = "https://dict.hjenglish.com/w/{0}";
        private static string JP_DICT = "https://dict.hjenglish.com/jp/jc/{0}";

        private static string DICT = JP_DICT;

        private delegate Word WordDeal(string result);

        private static void Init()
        {
            if (File.Exists(Para.LOG_PATH))
            {
                File.Delete(Para.LOG_PATH);
            }

            ThreadPool.SetMaxThreads(1000, 1000);
            Directory.CreateDirectory(resPath);

            DICT = EN_DICT;
            DealFile = "words.en.txtemp";
        }

        static void Main(string[] args)
        {
            Init();
            DoWork();

            Console.Write("end");
            Console.ReadLine();
        }

        /// <summary>
        /// 开始干活
        /// </summary>
        private static void DoWork()
        {
            string wordsFile = Path.Combine(LocalPath, DealFile);
            StreamReader sr = new StreamReader(wordsFile);


            string line = "";
            
            Regex wordRegex = new Regex(".*");
            if (DICT.Equals(EN_DICT))
            {
                wordRegex = new Regex("^[a-zA-Z]+$");
            }
            while((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                if (wordRegex.IsMatch(line))
                {
                    Word w = HttpGet(line);
                    WriteWord(w);
                }
            }

        }

        /// <summary>
        /// http请求释义
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        private static Word HttpGet(string w)
        {
            Word word = null;
            try
            {
                string url = string.Format(DICT, w);
                HttpWebRequest requst = WebRequest.CreateHttp(url);
                requst.Method = "Get";
                HttpWebResponse response = (HttpWebResponse)requst.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string result = sr.ReadToEnd();

                if (DICT.Equals(EN_DICT))
                {
                    word = new WordDeal(DealWordEn)(result);
                }
                else if (DICT.Equals(JP_DICT))
                {
                    word = new WordDeal(DealWordJp)(result);
                }
                
                WriteWotd2DB(word);
                //ThreadPool.QueueUserWorkItem(new WaitCallback(WriteWotd2DB), word);

                Dictionary<string, string> para = new Dictionary<string, string>();
                para.Add("url", word.Audio);
                para.Add("resName", word.Value);
                ThreadPool.QueueUserWorkItem(new WaitCallback(DownResource), para);

            }
            catch(Exception ex)
            {
                Log.Write("GetWord Filed [{0}]\t{1}", w, ex.Message);
            }
            return word;
        }

        /// <summary>
        /// 处理英文单词
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        private static Word DealWordEn(string result)
        {
            WordEn word = new WordEn();

            string value = result.Class("word-text");
            string sample = result.Class("simple");
            string pronounces = result.Class("pronounces");
            string audio = pronounces.Class(Tag.span, "word-audio");

            string detail = result.Class("word-details-item detail");
            string detailEnEn = result.Class("word-details-item enen");
            string synant = result.Class("word-details-item synant");
            string inflections = result.Class("word-details-item inflections");
            string phrase = result.Class("word-details-item phrase");

            word.Value = value.FilterHTML();
            word.Sample = sample.FilterHTML();
            word.Pronounces = pronounces.FilterHTML();
            word.Audio = audio.Attr("data-src");

            word.PronouncesEn = Regex.Replace(word.Pronounces, "美.\\[.*?\\]", "").Trim();
            word.PronouncesUs = Regex.Replace(word.Pronounces, "英.\\[.*?\\]", "").Trim();

            word.Detail = detail.FilterHTML_();
            word.DetailEnEn = detailEnEn.FilterHTML_();
            word.Synant = synant.FilterHTML_();
            word.Inflections = inflections.FilterHTML();
            word.Phrase = phrase.FilterHTML_();

            return word;
        }

        /// <summary>
        /// 处理日文单词
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static Word DealWordJp(string result)
        {
            return null;
        }

        /// <summary>
        /// 下载资源
        /// </summary>
        /// <param name="o"></param>
        private static void DownResource(object o)
        {
            string url = "";
            string resName = "";
            try
            {
                Dictionary<string, string> para = o as Dictionary<string, string>;
                url = para["url"];
                resName = para["resName"];
                if (File.Exists(Path.Combine(resPath, resName + ".mp3"))) return;

                HttpWebRequest requst = WebRequest.CreateHttp(url);
                requst.Method = "Get";
                HttpWebResponse response = (HttpWebResponse)requst.GetResponse();
                Stream stream = response.GetResponseStream();

                string tempFile = Path.Combine(resPath, resName + ".temp");
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                byte[] bytes = new byte[1024 * 4];
                int size = 0;
                while ((size = stream.Read(bytes, 0, bytes.Length)) > 0)
                {
                    fs.Write(bytes, 0, size);
                }
                fs.Close();
                stream.Close();
                File.Move(tempFile, Path.Combine(resPath, resName + ".mp3"));
            }
            catch (Exception ex)
            {
                Log.Write("DownResource Filed [{0}]\t{1}", resName, ex.Message);
            }
            
        }

        /// <summary>
        /// 将查询的意思写入文件
        /// </summary>
        /// <param name="w"></param>
        private static void WriteWord(Word w)
        {
            Console.WriteLine(w.Value);
            string wordsFile_ = Path.Combine(LocalPath, "_" + DealFile);
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(wordsFile_, true);
                sw.WriteLine(w.ToString());

            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
            }
        }

        /// <summary>
        /// 写入数据库
        /// </summary>
        private static void WriteWotd2DB(object o)
        {

            Word word = (Word)o;
            string sql = "";
            try
            {

                if (word.GetType() == typeof(WordEn))
                {
                    WordEn w = word as WordEn;
                    w = (WordEn)w.FilterDB();
                    sql = "INSERT INTO WORD_EN(Value, PronouncesUs, Sample, Phrase, Detail, PronouncesEn, DetailEnEn, Synant, Inflections, AudioUrl, Audio) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',NULL)";
                    sql = string.Format(sql, w.Value, w.PronouncesUs, w.Sample, w.Phrase, w.Detail, w.PronouncesEn, w.DetailEnEn, w.Synant, w.Inflections, w.Audio);
                }
                else if(word.GetType() == typeof(WordJp))
                {

                }

                using (DbManager db = new DbManager())
                {
                    db.ExeceteQuery(sql);
                }
            }
            catch(Exception ex)
            {
                if(ex.GetType() == typeof(SqlException) && ((SqlException)ex).Number == 2627)
                {

                }
                else
                {
                    Log.Write("WriteWotd2DB Filed [{0}]\t{1}", word.Value, ex.Message);
                    Log.Write("SQL【{0}】", sql);
                }
            }
            
        }




    }
}
