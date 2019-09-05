using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileParser
{
    class StringsCounter : TextHandler
    {
        public string entry { get; set; }


        protected override IEnumerator<int> GetEnumeratorImpl(StreamReader stream)
        {
            string forSearch;

            int amount = 0;
            try
            {
                while (!stream.EndOfStream)
                {
                    forSearch = stream.ReadLine();

                    amount = Regex.Split(forSearch.ToLower(), @"\W+")
                                    .Where(x => x == entry).Count();

                    yield return amount;
                }
            }
            finally
            {
                stream.Dispose();
            }
        }
    }
}
