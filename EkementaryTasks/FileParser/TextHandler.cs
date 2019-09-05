using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    abstract class TextHandler : IEnumerable<int>
    {
        protected const int DefaultBufferSize = 10240;

        public Encoding DefaultEncoding { get; set; } = Encoding.UTF8;

        public readonly string FilePath;

        public int Amount { get; protected set; }

        //protected StreamReader Stream;



        public TextHandler(string path)
        {
            FilePath = path;
        }


        public abstract IEnumerator<int> GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
