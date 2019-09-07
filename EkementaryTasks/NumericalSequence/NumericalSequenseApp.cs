using System;
using System.Collections;
using AdditionalClasses;
using Interfaces;

namespace NumericalSequence
{
    class NumericalSequenseApp
    {
        #region privatfields

        private IStringParser _parser = new Parser();

        private Counter _counter = new Counter();

        private IStringValidator _stringValidator = new Validator();

        private IUserCommunication _userCommunication;

        #endregion

        #region public fields
        public string input { get; set; }

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

        #region ctors
        public NumericalSequenseApp(IUserCommunication communication)
        {
            userCommunication = communication;
        }

        #endregion
        public void AppStart()
        {
            string s = _userCommunication.GetUserInput(startMessage);

            if (_stringValidator.IsValid(s))
            {

                bool isDigitsFound;

                s = _parser.ExtractDigits(s, out isDigitsFound);

                _userCommunication.Message("Passed number: ");

                if (!isDigitsFound)
                {
                    _userCommunication.MessageLn(s);

                    printInstructions();
                }
                _userCommunication.MessageLn(s);

                input = s;

                rangedNumericalSequence = _counter.GetSequence(input);

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
        public void printInstructions()
        {
            _userCommunication.Message(remark);

            _userCommunication.Message(instructions);
        }
    }
}
