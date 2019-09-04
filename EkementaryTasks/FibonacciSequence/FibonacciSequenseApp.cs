﻿using System;
using System.Collections;
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

        public double from { get; set; }
        public double to { get; set; }

        private IParser _parser = new Parser();

        private Counter _counter = new Counter();

        private IValidator _validator = new Validator();

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

            if (validate(args[0]) & validate(args[1]))
            {
                bool hasDigits;

                range = _parser.ExtractDigits(args, out hasDigits);


                _userCommunication.Message("Passed range ");

                _userCommunication.PrintArqs(range);

                if (hasDigits & _validator.IsValidNumbers(range))
                {

                    from = range[0];
                    to = range[1];

                    rangedFibonacciSequence = _counter.GetSequence(from, to);

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

        private bool validate(string s)
        {
            if (_validator.IsValid(s, validCheks.stringIsEmpty))
            {
                _userCommunication.Warning(StringsConstants.empty);
                return false;
            }

            if (_validator.IsValid(s, validCheks.stringHasWhitheSpaces))
            {
                _userCommunication.Warning(StringsConstants.whiteSpace);
                return false;
            }

            return true;
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
