using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public interface IFileParserView
    {
        Enum ChooseMode(string question);

        string[] GetUserInput(string[] startMessage);

        bool WantContinue();
    }
}
