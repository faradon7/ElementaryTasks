using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSequence
{
    public static class StringValidator
    {
       

        public static bool Validate(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
