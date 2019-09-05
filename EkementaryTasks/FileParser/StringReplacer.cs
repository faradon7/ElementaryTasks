using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileParser
{
    class StringReplacer : TextHandler
    {
        public string entry { get; set; }


        protected override IEnumerator<int> GetEnumeratorImpl(StreamReader stream)
        {
            string[] words;
            try
            {
                int amount = 0;
                while (!stream.EndOfStream)
                {


                    yield return amount = new Regex(stream.ReadLine()).Matches(entry).Count;
                }
            }
            finally
            {
                stream.Dispose();
            }
        }
    }
}
