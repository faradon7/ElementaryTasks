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
        public abstract string Entry { get; }

        public int Amount { get; protected set; }

        protected ReadStreamProvider _reader;

        protected WriteStreamProvider _writer;

        public TextHandler(string path)
        {
            _reader = new ReadStreamProvider(path);

            _writer = new WriteStreamProvider(path);
        }

       
        //{
        //    string NextLine;

        //    long streamLength;

        //    long nextLinePosition = 0L;

        //    do
        //    {
        //        using (var sr = _reader.GetReader())
        //        {
        //            streamLength = _reader.Length;

        //            sr.BaseStream.Position = nextLinePosition;

        //            NextLine = sr.ReadLine();

        //            nextLinePosition += Encoding.UTF8.GetByteCount(NextLine) + 2;
        //        }

        //        yield return NextLine;

        //    } while (nextLinePosition < streamLength);
        //}

    }
}

