using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjDict
{
    public class Word
    {
        public string Value { get; set; }
        public string Sample { get; set; }
        public string Pronounces { get; set; }
        public string Audio { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", Value, Pronounces, Sample);
        }
    }


    //public class WordEn : word
    //{

    //}
}
