using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class StringsConstants
    {
        #region input

        public const string startMessage = "Enter range of Fibonacci numbers sequence";

        public const string inputFirstArg = "Input first argument and press enter key: ";

        public const string inputSecondArg = "Input second argument and press enter key: ";

        #endregion

        #region warnings

        public const string empty = "Empty line was passed!!!";

        public const string whiteSpace = "White spaces were found in the line";

        public const string digits = "The following numbers were found.";

        public const string NotFound = "Fibonacci numbers not found.";

        #endregion

        #region remarks

        public const string wantContinue = 
            "Enter [Y] or [YES] if you want to continue, or press enter key if you want to close application: ";

        #endregion

    }
}
