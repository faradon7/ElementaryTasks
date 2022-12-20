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
        stringHasWhiteSpaces,
        isNumber
    }
    public interface IStringValidator
    {
        bool IsValid(string s, validCheks check);
    }
}
