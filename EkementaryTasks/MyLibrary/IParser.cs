using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public interface IParser
    {
        string ExtractDigits(string s, out bool isExtracted);

        double[] ExtractDigits(string[] args, out bool isExtracted);
    }
}
