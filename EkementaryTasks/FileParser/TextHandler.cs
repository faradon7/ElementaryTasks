using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    abstract class TextHandler : IEnumerable<int>
    {
        private const int DefaultBufferSize = 10240;

        public Func<Stream> streamSource;

        public readonly Encoding encoding;

        public StreamReader stream;



        public IEnumerator<int> GetEnumerator()
        {
            return GetEnumeratorImpl(stream);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected abstract IEnumerator<int> GetEnumeratorImpl(StreamReader stream);
    }
}
