using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    interface IChessBoardView
    {
        void PrintCell(Cell cell);

        string[] GetUserInput(string[] startMessage);

        //void PrintInstructions(StringBuilder sb);

        //void Warning(string message);

        //void Message(string message);

        //bool WantContinue();
    }
}
