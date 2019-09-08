using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace NumericalSequence
{
    class Program
    {

        public static NumericalSequenceApp NumericalSequence { get; } = new NumericalSequenceApp(new ConsoleUI());


        static void Main(string[] args)
        {
            NumericalSequence.AppStart();
        }

        
                            
    }
}
