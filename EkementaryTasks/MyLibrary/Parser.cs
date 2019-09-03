using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyLibrary
{
    public class Parser : IParser
    {
        public string ExtractDigits(string s, out bool isExtracted)
        {
            string parsedString = string.Empty;

            Regex regex = new Regex(@"\d+");

            MatchCollection matches = regex.Matches(s);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    parsedString += match.Value;
                }

                isExtracted = true;

             return parsedString;
            }
            else
            {
                isExtracted = false;
                return "No digits found";
            }
        }
    }
}
