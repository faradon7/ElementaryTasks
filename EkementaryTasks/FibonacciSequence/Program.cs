using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers;
using NLog;

namespace FibonacciSequence
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static FibonacciSequenceApp Application = new FibonacciSequenceApp(new ConsoleUI());

        static void Main(string[] args)
        {
            _logger.Debug("Running the main application method");
            Application.AppStart();
        }
    }
}
