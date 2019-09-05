using System;
using System.Text.RegularExpressions;
using Interfaces;

namespace AdditionalClasses
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
        public double[] ExtractDigits(string[] args, out bool isExtracted)
        {
            double[] parsedNumbers = new double[args.Length];

            isExtracted = true;

            Regex regex = new Regex(@"\d+");

            for (int i = 0; i < args.Length; i++)
            {
                string mathcString = string.Empty;
                double rangeArg;

                MatchCollection matches = regex.Matches(args[i]);

                if (!(matches.Count > 0))
                {
                    isExtracted = false;
                    continue;
                }

                foreach (Match match in matches)
                {
                    mathcString = match.Value;
                }
                    bool result = double.TryParse(mathcString, out rangeArg);

                parsedNumbers[i] = (rangeArg == 0) ? 1 : rangeArg;
            }

            return parsedNumbers;
        }
    }
}
