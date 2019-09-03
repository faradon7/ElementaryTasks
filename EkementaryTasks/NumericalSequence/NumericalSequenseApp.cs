using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace NumericalSequence
{
    class NumericalSequenseApp
    {
        #region fields

        public string input { get; set; }

        private IParser parser = new Parser();

        private Counter counter = new Counter();

        private IStringValidator stringValidator = new StringValidator();

        private IUserCommunication _userCommunication;

        public const string instructions =
           "Then the program will return the sequence of natural numbers whose square is less than a given number.";

        public const string startMessage = "Enter integer natural number: ";

        public const string remark = "For correct operation, enter an integer natural number.";


        #endregion

        #region properties

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

        #region methods

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
                    _userCommunication.Message(s);

                    printInstructions();
                }
                _userCommunication.Message(s);

                input = s;

                counter.PrintNaturalRow(input, userCommunication);
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

        #endregion
    }

}
