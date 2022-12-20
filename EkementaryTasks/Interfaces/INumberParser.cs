using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface INumberParser
    {
        double[] ExtractDigits(string[] args, out bool isExtracted);
    }
}
