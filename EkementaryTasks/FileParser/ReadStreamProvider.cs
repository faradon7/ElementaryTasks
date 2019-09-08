using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParser
{
    class ReadStreamProvider
    {
        public string FilePath { get; private set; }

        protected const int DefaultBufferSize = 10240;

        public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;

        public long Length { get; private set; }

        public ReadStreamProvider(string path)
        {
            FilePath = path;
        }

        public StreamReader GetReader()
        {
            Stream stream = File.OpenRead(FilePath);
            StreamReader Reader = new StreamReader(stream, DefaultEncoding, true, DefaultBufferSize);
                Length = stream.Length;
                return Reader;
        }

    }
}
