using System.Text;
using System.IO;
using Interfaces;
using NLog;

namespace FileParser
{
    class WriteStreamProvider : IWriteStreamProvider
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        protected const int DefaultBufferSize = 10240;

        public string FilePath { get; }

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
            _logger.Debug("Get StreamWriter attemp");
            StreamWriter writer = new StreamWriter(_tempFile, true, DefaultEncoding, DefaultBufferSize);

            return writer;
        }

        public void ReplaceWithTempFile()
        {
            File.Replace(_tempFile, FilePath, _backUp);
        }
    }
}
