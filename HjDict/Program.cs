using System;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {
            ThreadPool.SetMaxThreads(1000, 1000);
            Directory.CreateDirectory(resPath);
            DoWork();
            Console.Write("end");
            Console.ReadLine();
        }

        private static void DoWork()
        {
            string wordsFile = Path.Combine(LocalPath, DealFile);
            StreamReader sr = new StreamReader(wordsFile);


            string line = "";
            
            Regex wordRegex = new Regex("^[a-zA-Z]+$");
            if (DICT.Equals(JP_DICT))
            {
                wordRegex = new Regex(".*");
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

        private static Word HttpGet(string w)
        {
            Word word = new Word();
            try
            {
                string url = string.Format(DICT, w);
                HttpWebRequest requst = WebRequest.CreateHttp(url);
                requst.Method = "Get";
                HttpWebResponse response = (HttpWebResponse)requst.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string result = sr.ReadToEnd();

                string sample = result.Class("simple");
                string pronounces = result.Class("pronounces");
                string audio = pronounces.Class("span", "word-audio");


                word.Value = w;
                word.Sample = sample.FilterHTML();
                word.Pronounces = pronounces.FilterHTML();
                word.Audio = audio.Attr("data-src");

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
                byte[] bytes = new byte[1024];
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

    }
}
