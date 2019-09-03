using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace NumericalSequence
{
    class Program
    {

        public static NumericalSequenseApp NumericalSequence { get; } = new NumericalSequenseApp(new ConsoleUI());


        static void Main(string[] args)
        {

            NumericalSequence.AppStart();

        }

        
                            
    }
}
