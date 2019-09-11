using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using Helpers;
using Interfaces;

namespace FileParser
{
    class Application
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #region fields

        public static string[] CountQuery =
            { "Enter file path: ", "Enter string to count: " };

        public static string[] ReplaceQuery =
            { "Enter file path: ", "Enter string to replace: ",
                            "Enter replacement string: " };

        private IFileValidator _fileValidator = new FileValidator();

        private IFileParserView _userCommunication;

        public int Amount = 0;

        #endregion

        #region properties

        public IFileParserView UserCommunication
        {
            get { return _userCommunication; }

            set
            {
                if (value == null)
                {
                    _logger.Fatal("User Interface wasn't passed!");
                    closeApp();
                }
                _userCommunication = value;
            }
        }

        private StringsCounter _counter { get; set; }

        private StringReplacer _replacer { get; set; }

        #endregion

        public Application(IFileParserView ui)
        {
            _userCommunication = ui;
        }

        public void AppStart()
        {
            bool wantContinue = false;

            do
            {
                _logger.Debug("Application requests to select mode ");
                Enum mode = _userCommunication.ChooseMode("Count the number of string entries or replace all string entries? [Count/Replace] ");

                string[] arqs;
                List<string> posibleErrors;

                switch (mode)
                {
                    case UserResponse.Count:

                        _logger.Info("Selected mode:" + UserResponse.Count);

                        arqs = getInputParameters(CountQuery);

                        _logger.Debug("File validation attempt");

                        if ((_fileValidator.validateAll(arqs[0], out posibleErrors)))
                        {
                            _logger.Info("File validation successful");
                            _counter = new StringsCounter(arqs[0], arqs[1]);

                            _counter.Count();

                            _userCommunication.Message($"Amount of entries: {_counter.Amount}");
                        }
                        else
                        {
                            printErrors(posibleErrors);
                        }

                        goto default;

                    case UserResponse.Replace:

                        arqs = getInputParameters(ReplaceQuery);

                        _logger.Debug("File validation attempt");

                        if ((_fileValidator.validateAll(arqs[0], out posibleErrors)))
                        {
                            _logger.Info("File validation successful");
                            _replacer = new StringReplacer(arqs[0], arqs[1], arqs[2]);

                            _replacer.Replace();

                            _logger.Info($"Amount of replaced strings: {_replacer.Amount}");
                            _userCommunication.Message($"Amount of replaced strings: {_replacer.Amount}");
                        }
                        else
                        {
                            printErrors(posibleErrors);
                        }

                        goto default;

                    default:

                        _logger.Debug("Сontinuation request");
                        wantContinue = _userCommunication.WantContinue();
                        break;
                }

            } while (wantContinue);

            closeApp();
        }

        public void printInstructions()
        {
            StringBuilder instructions = new StringBuilder("You can to count or replace some entry string in a file, ");

            instructions.Append("for this operation just choose appropriate mode thin enter next parametrs");
            instructions.AppendLine("* Enter the path to file you want to handle.");
            instructions.AppendLine("* Enter the string you want to handle in specified file.");
            instructions.AppendLine("* If it [Replace] mode you need elso to enter replacement string.");
            instructions.AppendLine("Then the program will count or replace specified string in the file,");
            instructions.AppendLine("and will output amount of entry strings or replaced strings.");

            _userCommunication.PrintInstructions(instructions);
        }

        private void printErrors(List<string> errors)
        {
            _logger.Error("File validation error");
            foreach (var item in errors)
            {
                _logger.Warn(item + " ");
                _userCommunication.Warning(item);
            }
        }

        private void closeApp()
        {
            _logger.Trace("Closing application");
            Environment.Exit(0);
        }

        private string[] getInputParameters(string[] queries)
        {
            _logger.Debug("Application requests user input");
            string[] args = _userCommunication.GetUserInput(queries);

            for (int i = 0; i < args.Length; i++)
            {
                _logger.Info(queries[i] + " " +
                    args[i]);
            }

            return args;
        }
    }
}
