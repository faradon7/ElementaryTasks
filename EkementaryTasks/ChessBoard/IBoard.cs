using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    interface IBoard
    {
        int Rows { get; set; }

        int Columns { get; set; }

        Cell[,] Cells { get; set; }

        Cell[,] GetBoard(int sizeOfCell = 6);

    }
}
