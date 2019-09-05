using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFileParserView
    {
        Enum ChooseMode(string question);

        string[] GetUserInput(string[] startMessage);

        string GetUserInput(string startMessage);

        void Message(string message);

        void Warning(string message);

        bool WantContinue();
    }
}
