using NLog;
using Helpers;

namespace FileParser
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Application app = new Application(new ConsoleUI());
            _logger.Debug("Running the main application method");
            app.AppStart();
        }
    }
}
