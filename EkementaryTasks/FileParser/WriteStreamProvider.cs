using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParser
{
    class WriteStreamProvider
    {
        public string FilePath { get; }

        protected const int DefaultBufferSize = 10240;

        public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;

        private string _tempFile;

        private string _backUp;

        public WriteStreamProvider(string path)
        {
            FilePath = path;

            _tempFile = Path.ChangeExtension(Path.GetTempFileName(), "txt");

            _backUp = Path.ChangeExtension(Path.GetTempFileName(), "txt");
        }


        public StreamWriter GetWriter()
        {
            StreamWriter writer = new StreamWriter(_tempFile, true, DefaultEncoding, DefaultBufferSize);

                return writer;
        }

        public void ReplaceWithTempFile()
        {
            File.Replace(_tempFile, FilePath, _backUp);
        }
    }
}
