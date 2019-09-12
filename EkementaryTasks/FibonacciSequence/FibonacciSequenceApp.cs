using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Helpers;
using Interfaces;
using NLog;

namespace FibonacciSequence
{
    class FibonacciSequenceApp
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        #region fields

        private IUserCommunication _userCommunication;

        private INumberParser _parser;

        private IStringValidator _stringValidator;

        private INumberValidator _numberValidator;

        private SequenceGenerator _generator;

        #endregion

        #region properties

        public int From { get; private set; }

        public int To { get; private set; }

        public IEnumerable<int> RangedFibonacciSequence { get; private set; }

        public IUserCommunication UserCommunication
        {
            get { return _userCommunication; }

            set
            {
                if (value == null)
                {
                    _logger.Fatal("User Interface wasn't passed!");
                    CloseApp();
                }

                _userCommunication = value;
            }
        }

        #endregion

        public FibonacciSequenceApp(IUserCommunication communication)
        {
            UserCommunication = communication;
            _logger.Debug("Selected UI " + communication);

            _parser = new Parser();

            _stringValidator = new Validator();

            _numberValidator = new Validator();

            _generator = new SequenceGenerator();

            RangedFibonacciSequence = new List<int>();

        }

        public void AppStart()
        {
            bool wantContinue = false;

            do
            {
                UserCommunication.Message(StringsConstants.startMessage);

                string[] start = new[] {
                    "From what number to start the search for values: ",
                    "To which number to look for values: " };
                _logger.Info("Application requests an input parameters");

                string[] args = _userCommunication.GetUserInput(start); //TODO: проверка на тип
                int[] range = new int[2];
                _logger.Info("User passed range for search from " +
                    args[0] + "to " + args[1]);

                _logger.Debug("User input validation attempt");
                if (_stringValidator.IsValid(args[0]) & _stringValidator.IsValid(args[1]))
                {
                    _logger.Info("User input validation was successful");
                    bool hasDigits;

                    _logger.Debug("Extract digits from input attemp");
                    range = _parser.ExtractDigits(args, out hasDigits);

                    _userCommunication.Message("Passed range ");

                    _userCommunication.PrintArqs(range);

                    _logger.Debug("Validation parsed range attemp");
                    if (hasDigits & _numberValidator.IsValidNumbers(range))
                    {
                        _logger.Info("Next range extracted " + range[0]
                            + "-" + range[1]);
                        _logger.Info("Range is valid");

                        From = range[0];
                        To = range[1];

                        _logger.Debug("Sequnce generator launching");
                        RangedFibonacciSequence = _generator.GetSequence(From, To);

                        _userCommunication.Message("Fibonacci sequense in specified range: ");

                        _userCommunication.Message(string.Join(", ", RangedFibonacciSequence));
                        _logger.Info("Generated sequence " +
                            string.Join(", ", RangedFibonacciSequence));

                        if (_generator.GreaterNearest == 0)
                        {
                            _userCommunication.Message(StringsConstants.NotFound);
                            _logger.Warn(StringsConstants.NotFound);
                        }
                    }
                    else
                    {
                        _userCommunication.Warning("Incorrect range ");

                        _logger.Warn("Digits not found or second value of range less then first" +
                            range[0] + "-" + range[1]);

                        _userCommunication.Warning("Digits not found " +
                            "or second value of range less then first ");

                        printInstructions();
                        _logger.Trace("Instructions for application was printed");
                    }
                }
                else
                {
                    _logger.Error("User input is empty or has white spaces!"
                        + "User input from: " + args[0] + "to" + args[1]);
                    printInstructions();
                }

                _logger.Debug("Сontinuation request");
                wantContinue = _userCommunication.WantContinue();

            } while (wantContinue);

            CloseApp();
        }

        public void printInstructions()
        {
            StringBuilder instructions =
                new StringBuilder("You need to enter range of natural numbers: ");

            instructions.AppendLine("First argument must be greater the second.");

            instructions.AppendLine("Then the program will return the sequence " +
                "of Fibonacci numbers in the specified range.");

            _userCommunication.PrintInstructions(instructions);
        }

        public void CloseApp()
        {
            _logger.Trace("Closing application");
            Environment.Exit(0);
        }
    }
}
