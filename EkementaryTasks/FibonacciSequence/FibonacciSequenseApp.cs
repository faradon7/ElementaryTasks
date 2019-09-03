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

        public string input { get; set; }

        private IParser parser = new Parser();

        private Counter counter = new Counter();

        private IStringValidator stringValidator = new StringValidator();

        private IUserCommunication _userCommunication;

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

            //if(!validate(firstArg))

            string secondArg = userCommunication.GetUserInput(StringsConstants.inputSecondArg);

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

    }
}
