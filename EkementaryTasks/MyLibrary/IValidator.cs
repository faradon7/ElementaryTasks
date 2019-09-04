using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public interface IValidator
    {
        bool IsValid(string s, validCheks check);

        bool IsValidNumbers(double[] range);
    }
}
