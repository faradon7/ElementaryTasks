using System.Collections.Generic;
using NLog;


namespace FileParser
{
    public abstract class TextEditor 
    {
        protected static Logger _logger = LogManager.GetCurrentClassLogger();

        protected IEnumerable<string> _lineEnumeration;

        public string Entry { get; set; }

        public int Amount { get; protected set; }

        public LineEnumerator LineEnumerator
        {
            get => default(LineEnumerator);
            set
            {
            }
        }

        protected TextEditor()
        {

        }

        public TextEditor(string path)
        {
            _lineEnumeration = new LineEnumerator(path);
        }
    }
}

