using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Interfaces;
using NLog;

namespace Helpers
{
    public class ReadStreamProvider : IReadStreamProvider
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        protected const int DefaultBufferSize = 10240;

        public string FilePath { get; }

        public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;

        public long Length { get; private set; }

        public ReadStreamProvider(string path)
        {
            FilePath = path;
        }

        public StreamReader GetReader()
        {
            _logger.Debug("Get StreamReader attemp");
            Stream stream = File.OpenRead(FilePath);
            StreamReader Reader = new StreamReader(stream, DefaultEncoding, true, DefaultBufferSize);
            Length = stream.Length;
            return Reader;
        }

    }
}
