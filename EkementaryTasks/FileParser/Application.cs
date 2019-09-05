using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AppStart()
        {
            Enum mode = _userCommunication.ChooseMode("Count the number of string entries or replace all string entries? [Count/Replace] ");

            string[] arqs;

            string[] posibleErrors = new string[3];

            switch (mode) // можно и ifами
            {
                case UserResponse.Count:
                    {
                        arqs = _userCommunication.GetUserInput(new[] { "Enter file path: ", "Enter string to count: " });

                        if (_fileValidator.validateAll(arqs[0], out posibleErrors))
                        {
                             StringsCounter counter = new StringsCounter(arqs[0], arqs[1]);

                             int amount = counter.Count();

                            _userCommunication.Message($"Amount of replaced strings: {amount}");
                        }
                        else
                        {
                            foreach (var item in posibleErrors)
                            {
                                _userCommunication.Warning(item);
                            }
                        }

                        goto default;
                    }
                case UserResponse.Replace:
                    {
                        arqs = _userCommunication.GetUserInput(new[] { "Enter file path: ", "Enter string to replace: ", "Enter replacement string: " });

                        if (_fileValidator.validateAll(arqs[0], out posibleErrors))
                        {
                            StringReplacer replacer = new StringReplacer(arqs[0], arqs[1], arqs[2]);

                            int amount = replacer.Replace();

                            _userCommunication.Message($"Amount of replaced strings: {amount}");
                        }
                        else
                        {
                            foreach (var item in posibleErrors)
                            {
                                _userCommunication.Warning(item);
                            }
                        }

                        goto default;
                    }
                case UserResponse.Exit:
                    {
                        goto default;
                    }
                default:
                    {
                        if (_userCommunication.WantContinue())
                        {
                            AppStart();
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;
                    }

            }
        }
    }
}
