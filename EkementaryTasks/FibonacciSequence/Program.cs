using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace FibonacciSequence
{
    class Program
    {
        public static FibonacciSequenceApp Agregate = new FibonacciSequenceApp(new ConsoleUI());
        static void Main(string[] args)
        {
            Agregate.AppStart();
        }
    }
}
