using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public interface IStringValidator
    {
        bool IsValid(string s, validCheks check);
    }
}
