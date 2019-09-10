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

        private string FileName { get; set; }

        public readonly string Substitute;

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
            var watch = System.Diagnostics.Stopwatch.StartNew();
            using (var sw = _writer.GetWriter())
            {
                foreach (var line in _lineEnumeration)
                {
                    string currentLine = string.Empty;

                    if (line.Contains(Entry))
                    {
                        currentLine = line.Replace(Entry, Substitute);
                        Amount += currentLine.Split(new string[] { Substitute }, StringSplitOptions.None).Length - 1;
                    }
                    else
                    {
                        sw.WriteLine(line);
                        continue;
                    }
                    sw.WriteLine(currentLine); // writing to file
                }
            }
            _writer.ReplaceWithTempFile();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
