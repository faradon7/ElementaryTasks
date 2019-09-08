using System;
using Interfaces;

namespace Helpers
{
    public class Validator : IStringValidator, INumberValidator
    {
        public bool IsValid(string s, validCheks check)
        {
            switch (check)
            {
                case validCheks.stringIsEmpty:
                    {
                        return string.IsNullOrEmpty(s);
                    }
                case validCheks.stringHasWhiteSpaces:
                    {
                        return string.IsNullOrWhiteSpace(s);
                    }
                case validCheks.isNumber:
                    {
                        int i;

                        return (Int32.TryParse(s, out i));
                    }
                default: return false;
            }
        }

        public bool IsValidNumbers(double[] range)
        {
            return (range[0] < range[1]);
        }
    }
}
