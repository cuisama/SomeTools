using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjDict
{
    /// <summary>
    /// html标签
    /// </summary>
    public enum Tag {

        div = 0,
        span = 1,

    }

    /// <summary>
    /// 单词
    /// </summary>
    public class Word
    {
        public string Value { get; set; }
        public string Sample { get; set; }
        public string Pronounces { get; set; }
        public string Detail { get; set; }
        public string Audio { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", Value, Pronounces, Sample);
        }
    }

    /// <summary>
    /// 英文单词
    /// </summary>
    public class WordEn : Word
    {
        /// <summary>
        /// 英式发音
        /// </summary>
        public string PronouncesEn { get; set; }
        /// <summary>
        /// 美式发音
        /// </summary>
        public string PronouncesUs { get; set; }
        /// <summary>
        /// 英英释义
        /// </summary>
        public string DetailEnEn { get; set; }
        /// <summary>
        /// 常用短语
        /// </summary>
        public string Phrase { get; set; }
        /// <summary>
        /// 同反义词
        /// </summary>
        public string Synant { get; set; }
        /// <summary>
        /// 词形变化
        /// </summary>
        public string Inflections { get; set; }
    }

    /// <summary>
    /// 日文单词
    /// </summary>
    public class WordJp : Word
    {
        /// <summary>
        /// 扩展词汇
        /// </summary>
        public string Synant { get; set; }
    }
}
