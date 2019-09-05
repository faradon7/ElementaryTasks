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
        public StreamReader Reader { get; set; }

        public readonly string Entry;


        public StringsCounter(string path, string entry) : base(path)
        {
            Entry = entry.ToLowerInvariant();
        }

        public int Count()
        {
            Stream stream = File.OpenRead(@"C:\Users\farik\EkementaryTasks\Biblija.txt");

            Reader = new StreamReader(stream, DefaultEncoding, true, DefaultBufferSize);

            Amount = 0;

            foreach (var item in this)
            {
                Amount += item;
            }
            return Amount;
        }

        public override IEnumerator<int> GetEnumerator()
        {
            return GetEnumeratorImpl(Reader);
        }

        public IEnumerator<int> GetEnumeratorImpl(StreamReader stream)
        {
            string tempLine;

            int amount = 0;
            try
            {
                while (!stream.EndOfStream)
                {
                    tempLine = stream.ReadLine();

                    amount = Regex.Split(tempLine, @"\W+")
                                    .Where(x => x.ToLowerInvariant() == Entry).Count();

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
