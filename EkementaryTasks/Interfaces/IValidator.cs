using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public enum validCheks
    {
        stringIsEmpty,
        stringHasWhitheSpaces,
        isNumber
    }
    public interface IValidator
    {
        bool IsValid(string s, validCheks check);

        bool IsValidNumbers(double[] range);
    }
}
