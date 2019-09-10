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
        private WriteStreamProvider _writer;

        public readonly string Substitute;

        private string FileName { get; set; }

        public override string Entry { get; }

        public StringReplacer(string path, string entry, string substitute) :
            base(path)
        {
            _writer = new WriteStreamProvider(path);

            FileName = Path.GetFileNameWithoutExtension(path);

            Entry = entry;

            Substitute = substitute;
        }

        public void Replace()
        {
            string currentLine = string.Empty;

            using (var sw = _writer.GetWriter())
            using (var sr = _reader.GetReader())
            {
                do
                {
                    currentLine = sr.ReadLine();   // reading from file 

                    if (currentLine.Contains(Entry))
                    {
                        currentLine = currentLine.Replace(Entry, Substitute);

                        Amount += currentLine.Split(new string[] { Substitute }, StringSplitOptions.None).Length - 1;

                    }
                    sw.WriteLine(currentLine); // writing to file

                } while (!sr.EndOfStream);
            }
            _writer.ReplaceWithTempFile();
        }
    }
}
