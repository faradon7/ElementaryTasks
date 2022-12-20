using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalClasses;
using Interfaces;

namespace NumericalSequence
{
    class NumericalSequenseApp
    {
        #region fields

        public string input { get; set; }

        private IStringParser parser = new Parser();

        private Counter counter = new Counter();

        private IStringValidator stringValidator = new Validator();

        private IUserCommunication _userCommunication;

        public const string instructions =
           "Then the program will return the sequence of natural numbers whose square is less than a given number.";

        public const string startMessage = "Enter integer natural number: ";

        public const string remark = "For correct operation, enter an integer natural number.";


        #endregion

        #region properties

        public IEnumerable rangedNumericalSequence { get; private set; }

        public IUserCommunication userCommunication
        {
            get { return _userCommunication; }

            set {
                    if (value == null)
                    {
                        throw new ArgumentNullException();
                    }

                _userCommunication = value; }
        }

        #endregion

        public NumericalSequenseApp(IUserCommunication communication)
        {
            userCommunication = communication;
        }

        public void AppStart()
        {
            string s = _userCommunication.GetUserInput(startMessage);

            if (validate(s))
            {

                bool isDigitsFound;

                s = parser.ExtractDigits(s, out isDigitsFound);

                _userCommunication.Message("Passed number: ");

                if (!isDigitsFound)
                {
                    _userCommunication.MessageLn(s);

                    printInstructions();
                }
                _userCommunication.MessageLn(s);

                input = s;

                rangedNumericalSequence = counter.GetSequence(input);

                _userCommunication.Message("Sequense of natural numbers whose square is less than a specified number: ");
                _userCommunication.Print(rangedNumericalSequence);
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

            if (stringValidator.IsValid(s, validCheks.stringHasWhiteSpaces))
            {
                _userCommunication.Message(StringsConstants.whiteSpace);
                return false;
            }

            return true;
        }

        public void printInstructions()
        {
            _userCommunication.Message(remark);

            _userCommunication.Message(instructions);
        }
    }

}
