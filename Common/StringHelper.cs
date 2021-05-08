using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public static class StringHelper
    {
        public static string ConvertToUnSign(string text)
        {
            text = text.Trim();
            for (int i = 32; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), " ");
            }

            text = text.Replace(".", "-");

            text = text.Replace(" ", "-");

            text = text.Replace(",", "-");

            text = text.Replace(";", "-");

            text = text.Replace(":", "-");

            Regex regex = new Regex(@"p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            string str = regex.Replace(strFormD, String.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str.IndexOf("?") >= 0)
            {
                str = str.Remove(str.IndexOf("?"), 1);
            }
            while (str.Contains("--"))
            {
                str = str.Replace("--", "-").ToLower();
            }
            return str;

        }
    }
}
