using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace FibonacciSequence
{
    class FibonacciSequenseApp
    {
        #region fields

        public string from { get; set; }
        public string to { get; set; }

        private IParser parser = new Parser();

        private Counter counter = new Counter();

        private IStringValidator stringValidator = new StringValidator();

        private IUserCommunication _userCommunication;

        public const string instructions =
           "Then the program will return the sequence of Fibonacci numbers in the specified range.";

        public const string startMessage = "Enter range of Fibonacci numbers sequense: ";

        public const string remark = "For correct operation, enter an integer natural number.";
        
        #endregion

        #region properties

        #region properties

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

            string firstArg = userCommunication.GetUserInput(StringsConstants.inputFirstArg);

            string secondArg = userCommunication.GetUserInput(StringsConstants.inputSecondArg);

            if (validate(firstArg) & validate(firstArg))
            {
                bool hasDigitsFirst;
                bool hasDigitsSecond;

                firstArg = parser.ExtractDigits(firstArg, out hasDigitsFirst);
                secondArg = parser.ExtractDigits(secondArg, out hasDigitsSecond);

                _userCommunication.Message("Passed range: ");

                if (!(hasDigitsFirst & hasDigitsSecond))
                {
                    _userCommunication.Message(firstArg);

                    printInstructions();
                }

                _userCommunication.Message(firstArg);
                _userCommunication.Message(" ");
                _userCommunication.Message(secondArg);

                from = firstArg;
                to = secondArg;

                counter.GetSequence(from, to);
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

        private bool validate(string s)
        {
            if (stringValidator.IsValid(s, validCheks.stringIsEmpty))
            {
                _userCommunication.Message(StringsConstants.empty);
                return false;
            }

            if (stringValidator.IsValid(s, validCheks.stringHasWhitheSpaces))
            {
                _userCommunication.Message(StringsConstants.whiteSpace);
                return false;
            }

            return true;
        }

        public void printInstructions()
        {
            //StringBuilder remark =
            // new StringBuilder("For correct operation, enter an integer natural number.");

            //remark.AppendLine();

            //remark.Append("Then the program will return the row of natural ");
            //remark.Append("numbers whose square is less than a given number.");

            _userCommunication.Message(remark);

            _userCommunication.Message(instructions);
        }

    }
}
