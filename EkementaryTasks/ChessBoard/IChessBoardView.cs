using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    interface IChessBoardView
    {
        void PrintBoard(IBoard board);

        string[] GetUserInput(string[] startMessage);

        string GetUserInput(string startMessage);

        void PrintInstructions(StringBuilder sb);

        void Warning(string message);

        void Message(string message);

        bool WantContinue();
    }
}
