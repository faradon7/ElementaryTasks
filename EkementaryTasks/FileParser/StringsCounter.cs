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
        public override string Entry { get; }


        public StringsCounter(string path, string entry) : base(path)
        {
            Entry = entry.ToLowerInvariant();
        }

        public void Count()
        {
            string NextLine;

            long streamLength;

            long nextLinePosition = 0L;

            do
            {
                using (var sr = _reader.GetReader())
                {
                    streamLength = _reader.Length;

                    sr.BaseStream.Position = nextLinePosition;

                    NextLine = sr.ReadLine();

                    nextLinePosition += Encoding.UTF8.GetByteCount(NextLine) + 2;
                }

                Amount += Regex.Split(NextLine, @"\W+")
                                    .Where(x => x.ToLowerInvariant() == Entry).Count();

            } while (nextLinePosition < streamLength);
        }

        //public override IEnumerator<int> GetEnumerator()
        //{
        //    return GetEnumeratorImpl(Reader);
        //}

        //public IEnumerator<int> GetEnumeratorImpl(StreamReader stream)
        //{
        //    string tempLine;

        //    int amount = 0;
        //    try
        //    {
        //        while (!stream.EndOfStream)
        //        {
        //            tempLine = stream.ReadLine();

        //            amount = Regex.Split(tempLine, @"\W+")
        //                            .Where(x => x.ToLowerInvariant() == Entry).Count();

        //            yield return amount;
        //        }
        //    }
        //    finally
        //    {
        //        stream.Dispose();
        //    }
        //}
    }
}
