using System;
using System.Collections;
using System.Text;
using Helpers;
using Interfaces;

namespace FibonacciSequence
{

    class FibonacciSequenceApp
    {
        #region fields

        private IUserCommunication _userCommunication;

        private INumberParser _parser;

        private IStringValidator _stringValidator;

        private INumberValidator _numberValidator;

        private SequenceGenerator _generator;

        #endregion

        #region properties

        public double From { get; private set; }

        public double To { get; private set; }

        public IEnumerable rangedFibonacciSequence { get; private set; }

        public IUserCommunication userCommunication
        {
            get { return _userCommunication; }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(); //TODO: exception плохо!
                }

                _userCommunication = value;
            }
        }

        #endregion

        #region ctors


        public FibonacciSequenceApp(IUserCommunication communication)
        {
            userCommunication = communication;

            _parser = new Parser();

            _stringValidator = new Validator();

            _numberValidator = new Validator();

            _generator = new SequenceGenerator();

        }

        #endregion

        public void AppStart()
        {
            userCommunication.Message(StringsConstants.startMessage);


            var start = new[] { "From what number to start the search for values: ", "To which number to look for values: " };


            var args = _userCommunication.GetUserInput(start); //TODO: проверка на тип


            var range = new double[2];


            if (_stringValidator.IsValid(args[0]) & _stringValidator.IsValid(args[1]))
            {
                bool hasDigits;

                range = _parser.ExtractDigits(args, out hasDigits);


                _userCommunication.Message("Passed range ");

                _userCommunication.PrintArqs(range);

                if (hasDigits & _numberValidator.IsValidNumbers(range))
                {
                    From = range[0];

                    To = range[1];

                    rangedFibonacciSequence = _generator.GetSequence(From, To);

                    _userCommunication.Message("Fibonacci sequense in specified range: ");

                    _userCommunication.Print(rangedFibonacciSequence);
                }
                else
                {
                    _userCommunication.Warning("Incorrect range ");

                    _userCommunication.Warning("Digits not found or second value of range less then first ");

                    printInstructions();
                }

            }
            else
            {
                printInstructions();
            }

            if (_userCommunication.WantContinue())
            {
                AppStart();
            }

            Environment.Exit(0);
        }


        public void printInstructions()
        {
            StringBuilder instructions = new StringBuilder("You need to enter range of natural numbers: ");

            instructions.AppendLine("First argument must be greater the second.");

            instructions.AppendLine("Then the program will return the sequence of Fibonacci numbers in the specified range.");

            _userCommunication.PrintInstructions(instructions);
        }

    }
}
