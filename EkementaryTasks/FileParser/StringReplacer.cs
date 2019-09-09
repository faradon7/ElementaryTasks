using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FileParser
{
    class StringReplacer : TextHandler
    {
        public readonly string Substitute;

        private string FileName { get; set; }

        public override string Entry { get; }

        private Regex _regex { get; set; }

        public StringReplacer(string path, string entry, string substitute)
            : base(path)
        {
            FileName = Path.GetFileNameWithoutExtension(path);

            Entry = entry;

            Substitute = substitute;

            _regex = new Regex($"\b?({Entry})\b?");
        }

        public void Replace()
        {
            long streamLength;
            long nextLinePosition = 0L;

            do
            {
                string nextLine;

                using (var sr = _reader.GetReader())
                {
                    streamLength = _reader.Length;

                    sr.BaseStream.Position = nextLinePosition;

                    nextLine = sr.ReadLine();   // reading from file 

                    nextLinePosition += Encoding.UTF8.GetByteCount(nextLine) + 2;
                }

                nextLine = _regex.Replace(nextLine, Substitute);

                using (var sw = _writer.GetWriter())
                {
                    sw.WriteLine(nextLine); // writing to file
                }

                Amount += Regex.Split(nextLine, @"\W+")
                        .Where(x => x == Substitute).Count();
            } while (nextLinePosition < streamLength);

            _writer.ReplaceWithTempFile();
        }
    }
}
