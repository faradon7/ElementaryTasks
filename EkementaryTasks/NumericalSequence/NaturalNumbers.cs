using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace NumericalSequence
{
    class NaturalNumbers
    {
        #region fields

        public string input { get; set; }

        private Parser parser = new Parser();

        private Counter counter = new Counter();

        private IUserCommunication _userCommunication;

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

        #region methods

        public void GetSequense(IUserCommunication communication)
        {
            userCommunication = communication;

            string s;

            while (true)
            {
                s = _userCommunication.GetUserInput();

                if (StringValidator.Validate(s))
                {
                    bool isDigitsFound;

                    s = parser.ExtractDigits(s, out isDigitsFound);

                    _userCommunication.Message("Passed number: ");

                    if (isDigitsFound)
                    {
                        _userCommunication.Message(s);

                        input = s;

                        counter.PrintNaturalRow(input, userCommunication);
                    }
                    else
                    {
                        _userCommunication.Message(s);

                        GetRow();

                        continue;
                    }
                }
                else
                {
                    GetRow();

                }
            }
        }

        public void GetRow()
        {
            StringBuilder remark =
             new StringBuilder("For correct operation, enter an integer natural number.");

            remark.AppendLine();

            remark.Append("Then the program will return the row of natural ");
            remark.Append("numbers whose square is less than a given number.");

            _userCommunication.Output(remark);
        }

        #endregion

        //public Parser Parser
        //{
        //    get => default(Parser);
        //    set
        //    {
        //    }
        //}

        //public Counter Counter
        //{
        //    get => default(Counter);
        //    set
        //    {
        //    }
        //}
    }
}
