using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileParser
{
    class StringsCounter : TextHandler
    {
        public override string Entry { get; }
        
        public StringsCounter(string path, string entry) : base(path)
        {
            Entry = entry.ToLowerInvariant();
        }

        public void Count()
        {
                foreach (var line in _lineEnumeration)
                {
                    if (line.Contains(Entry))
                    {
                        Amount += line.Split(new string[] { Entry}, StringSplitOptions.None).Length - 1;
                    }
                }
        }
    }
}
