using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdditionalClasses;
using Interfaces;

namespace FileParser
{
    class Application
    {
        private IFileValidator _fileValidator = new FileValidator();

        private IFileParserView _userCommunication;

        public Application(IFileParserView ui)
        {
            _userCommunication = ui;
        }

        public int Amount = 0;

        public void AppStart()
        {
            bool wantContinue = false;

            do
            {
                Enum mode = _userCommunication.ChooseMode("Count the number of string entries or replace all string entries? [Count/Replace] ");

                string[] arqs;

                IList<string> posibleErrors;

                switch (mode)
                {
                    case UserResponse.Count:

                        arqs = _userCommunication.GetUserInput(new[] { "Enter file path: ", "Enter string to count: " });

                        if ((_fileValidator.validateAll(arqs[0], out posibleErrors)))
                        {

                            StringsCounter counter = new StringsCounter(arqs[0], arqs[1]);

                            counter.Count();

                            _userCommunication.Message($"Amount of replaced strings: {counter.Amount}");
                        }
                        else
                        {
                            foreach (var item in posibleErrors)
                            {
                                _userCommunication.Warning(item);
                            }
                        }

                        goto default;

                    case UserResponse.Replace:

                        arqs = _userCommunication.GetUserInput(new[] { "Enter file path: ", "Enter string to replace: ", "Enter replacement string: " });

                        if ((_fileValidator.validateAll(arqs[0], out posibleErrors)))
                        {

                            StringReplacer replacer = new StringReplacer(arqs[0], arqs[1], arqs[2]);

                            replacer.Replace();

                            _userCommunication.Message($"Amount of replaced strings: {replacer.Amount}");
                        }
                        else
                        {
                            foreach (var item in posibleErrors)
                            {
                                _userCommunication.Warning(item);
                            }
                        }

                        goto default;

                    default:

                        wantContinue = _userCommunication.WantContinue();
                        break;
                }

            } while (wantContinue);

            Environment.Exit(0);
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
    }
}
