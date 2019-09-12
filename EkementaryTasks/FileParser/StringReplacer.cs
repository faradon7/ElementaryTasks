using System;
using System.Collections.Generic;
using System.IO;
using Interfaces;

namespace FileParser
{
    class StringReplacer : TextTool
    {
        private IWriteStreamProvider _writer;

        private string FileName { get; set; }

        public readonly string Substitute;

        public StringReplacer(string entry, string substitute, IEnumerable<string> collection, IWriteStreamProvider writepr)
        {
            Substitute = substitute;
            Entry = entry;
            _lineEnumeration = collection;
            _logger.Debug("_lineEnumeration assigned custom collection");
            _writer = writepr;
        }

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
            _logger.Debug("Start replacing entries");
            using (var sw = _writer.GetWriter())
            {
                foreach (string line in _lineEnumeration)
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
                _logger.Info("Amount of replaced entries" + Amount);
            }
            _writer.ReplaceWithTempFile();
        }

        internal WriteStreamProvider WriteStreamProvider
        {
            get => default(WriteStreamProvider);
            set
            {
            }
        }
    }
}
