using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HjDict
{
    public static class Util
    {
        public static string Class(this string html,string clz)
        {
            return html.Class("div", clz);
        }

        public static string Class(this string html, string tag, string clz)
        {
            return Regex.Match(html, string.Format("<{0} class=\"{1}\"(.|\n)*?{0}>", tag, clz)).Value;
        }

        public static string Attr(this string document, string attr)
        {
            return Regex.Match(document, attr + "=\".*?\"").Value.Replace(attr + "=", "").Replace("\"", "").Replace("'", "");
        }

        public static string FilterHTML(this string html)
        {
            return Regex.Replace(html, "(<.*?>)|\n", "").Replace(" ", "");
        }


    }
}
