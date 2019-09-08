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

        public StringReplacer(string path, string entry, string substitute) : base(path)
        {
            FileName = Path.GetFileNameWithoutExtension(path);

            Entry = entry;

            Substitute = substitute;

            _regex = new Regex($"\b?({Entry})\b?");
        }

        public void Replace()
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

                NextLine = _regex.Replace(NextLine, Substitute);

                using (var sw = _writer.GetWriter())
                {
                    sw.WriteLine(NextLine);
                }

                Amount += Regex.Split(NextLine, @"\W+")
                                        .Where(x => x == Substitute).Count();

            } while (nextLinePosition < streamLength);

            _writer.ReplaceWithTempFile();
        }
    }
}
