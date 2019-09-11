using System.Collections.Generic;
using System.Collections;
using NLog;
using Interfaces;
using Helpers;

namespace FileParser
{
    public class LineEnumerator : IEnumerable<string>
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public IReadStreamProvider _provider;

        public LineEnumerator(string path)
        {
            _provider = new ReadStreamProvider(path);
        }

        public ReadStreamProvider ReadStreamProvider
        {
            get => default(ReadStreamProvider);
            set
            {
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
           return GetEnumeratorImpl(_provider);
        }

        public IEnumerator<string> GetEnumeratorImpl(IReadStreamProvider _provider)
        {
            _logger.Debug("Enumerate text file attemp");
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
