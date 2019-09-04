using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace FibonacciSequence
{
    class Program
    {
        public static FibonacciSequenseApp Agregate = new FibonacciSequenseApp(new ConsoleUI());
        static void Main(string[] args)
        {
            Agregate.AppStart();
        }
    }
}
