using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public interface IUserCommunication
    {
        string GetUserInput(string startMessage);

        void Output(double a);

        void Output(StringBuilder sb);

        void Message(string message);

        void Print(IEnumerable collection);

        bool WantContinue();

    }
}
