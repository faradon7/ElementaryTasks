using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FileParser.Tests")]
namespace FileParser
{
    class StringsCounter : TextTool
    {
        public StringsCounter(string entry, IEnumerable<string> collection)
        {
            Entry = entry.ToLowerInvariant();
            _lineEnumeration = collection;
            _logger.Debug("_lineEnumeration assigned custom collection");
        }

        public StringsCounter(string path, string entry) : base(path)
        {
            Entry = entry.ToLowerInvariant();
            _logger.Info("Entry string was reduced to lowercase");
        }

        public void Count()
        {
            _logger.Debug("Start entries counting");
            foreach (string line in _lineEnumeration)
            {
                if (line.ToLowerInvariant().Contains(Entry))
                {
                    Amount += line.ToLowerInvariant()
                        .Split(new string[] { Entry }, StringSplitOptions.None)
                        .Length - 1;
                }
            }
            _logger.Info("Amount entries found " + Amount);
        }
    }
}
