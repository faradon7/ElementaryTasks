using System;
using System.Collections;
using System.Text;
using AdditionalClasses;
using Interfaces;

namespace FibonacciSequence
{
    class FibonacciSequenseApp
    {
        #region fields

        public double From { get; set; }
        public double To { get; set; }

        private INumberParser _parser = new Parser();

        private SequenceGenerator _sequenceGenerator = new SequenceGenerator();

        private IStringValidator _stringValidator = new Validator();

        private INumberValidator _numberValidator = new Validator();

        private IUserCommunication _userCommunication;

        #endregion

        #region properties

        public IEnumerable rangedFibonacciSequence { get; private set; }

        public IUserCommunication userCommunication
        {
            get { return _userCommunication; }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                _userCommunication = value;
            }
        }

        #endregion

        #region ctors

        public FibonacciSequenseApp(IUserCommunication communication)
        {
            userCommunication = communication;
        }

        #endregion

        public void AppStart()
        {
            userCommunication.Message(StringsConstants.startMessage);

            string[] start = new [] { "From what number to start the search for values: ", "To which number to look for values: " };

            string[] args = _userCommunication.GetUserInput(start);

            double[] range = new double[2]; 

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

                    rangedFibonacciSequence = _sequenceGenerator.GetSequence(From, To);

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
