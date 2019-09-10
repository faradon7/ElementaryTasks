using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace FileParser
{
    class LineEnumerator : IEnumerable<string>
    {
        private ReadStreamProvider _provider;

        public LineEnumerator(string path)
        {
            _provider = new ReadStreamProvider(path);
        }

        public IEnumerator<string> GetEnumerator()
        {
           return GetEnumeratorImpl(_provider);
        }

        public IEnumerator<string> GetEnumeratorImpl(ReadStreamProvider _provider)
        {
            using (var sr = _provider.GetReader())
            {
                do
                {
                    string NextLine = sr.ReadLine();

                    yield return NextLine;

                } while (!sr.EndOfStream);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
