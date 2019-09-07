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
        public readonly string Substitute;

        private StreamReader Reader { get; set; }

        private StreamWriter Writer { get; set; }

        private string FileName { get; set; }

        public readonly string Entry;

        public StringReplacer(string path, string entry, string substitute) : base(path)
        {
            FileName = Path.GetFileNameWithoutExtension(path);

            Entry = entry;

            Substitute = substitute;
        }

        public int Replace()
        {
            Stream stream = File.OpenRead(FilePath);

            Reader = new StreamReader(stream, DefaultEncoding, true, DefaultBufferSize);

            string tempFile = Path.ChangeExtension(Path.GetTempFileName(), "txt");

            string backUp = Path.ChangeExtension(Path.GetTempFileName(), "txt");


            Writer = new StreamWriter(tempFile, true, DefaultEncoding, DefaultBufferSize);

            foreach (var item in this)
            {
                Amount += item;
            }

            File.Replace(tempFile, FilePath, backUp);

            return Amount;
        }

        public override IEnumerator<int> GetEnumerator()
        {
            return GetEnumeratorImpl(Reader);
        }

        protected IEnumerator<int> GetEnumeratorImpl(StreamReader stream)
        {
            var regex = new Regex($"\b?({Entry})\b?");
            

            try
            {

                string tempLine;

                while (!stream.EndOfStream)
                {
                    tempLine = stream.ReadLine();

                    tempLine = regex.Replace(tempLine, Substitute);

                    Writer.Write(tempLine);

                    yield return Regex.Split(tempLine, @"\W+")
                                    .Where(x => x == Substitute).Count();
                }
            }
            finally
            {
                stream.Dispose();
                Writer.Dispose();
            }
        }
    }
}
