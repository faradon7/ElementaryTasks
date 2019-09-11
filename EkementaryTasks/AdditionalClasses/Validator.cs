using System;
using Interfaces;

namespace Helpers
{
    public class Validator : IStringValidator, INumberValidator
    {
        public bool IsValid(string s)
        {
            int i = 0;
            if (string.IsNullOrEmpty(s))
            {
                
                return false;
            }
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            if (!Int32.TryParse(s, out i))
            {
                return false;
            }
            return true;
        }

        public bool IsValidNumbers(int[] range)
        {
            return (range[0] < range[1]);
        }
    }
}
