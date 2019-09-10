using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    abstract class TextHandler 
    {
        protected LineEnumerator _lineEnumeration;

        public abstract string Entry { get; }

        public int Amount { get; protected set; }

        public TextHandler(string path)
        {
            _lineEnumeration = new LineEnumerator(path);
        }
    }
}

