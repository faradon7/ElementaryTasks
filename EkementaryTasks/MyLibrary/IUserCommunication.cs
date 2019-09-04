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

        string[] GetUserInput(string[] startMessage);

        void PrintArqs(double[] args);

        void Output(StringBuilder sb);

        void PrintInstructions(StringBuilder sb);

        void Warning (string message);

        void Message (string message);

        void MessageLn (string message);

        void Print(IEnumerable collection);

        bool WantContinue();
    }
}
