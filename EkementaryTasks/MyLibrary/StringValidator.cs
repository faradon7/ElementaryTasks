using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLibrary
{
    public enum validCheks
    {
        stringIsEmpty,
        stringHasWhitheSpaces,
        isNumber
    }

    public class StringValidator : IStringValidator
    {
        public bool IsValid(string s, validCheks check)
        {
            switch (check)
            {
                case validCheks.stringIsEmpty:
                    {
                        return string.IsNullOrEmpty(s);

                    }
                case validCheks.stringHasWhitheSpaces:
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
    }
}
