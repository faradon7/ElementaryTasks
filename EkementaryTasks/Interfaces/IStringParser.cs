using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IStringParser
    {
        string ExtractDigits(string s, out bool isExtracted);
    }
}
