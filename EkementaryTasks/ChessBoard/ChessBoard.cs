using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class ChessBoard : IBoard
    {
        private int MoveCoursor = 0;
        private int LiftCoursor = 0;
        private IChessBoardView _userCommunication;

        public int Rows { get; set; }
        public int Columns { get; set; }
        public int NextRow = 0;

        public Cell[,] Cells { get; set; }


        public ChessBoard(int rows, int columns, IChessBoardView view)
        {
            Rows = rows;
            Columns = columns;
            Cells = new Cell[Rows, Columns];
            _userCommunication = view;

            GetBoard();
        }

        public Cell[,] GetBoard(int sizeOfCell = 6)
        {
            Cell.Size = sizeOfCell;

            bool colorSwitch = false;

            char[] whiteRow = new char[Cell.Size * 2];

            char[] blackRow = new char[Cell.Size * 2]; ;

            for (int i = 0; i < whiteRow.Length; i++)
            {
                whiteRow[i] = '█';

                blackRow[i] = ' ';
            }

            int t = Cells.GetUpperBound(0) + 1;


            for (int i = 0; i < t; i++)
            {
                if (Columns % 2 == 0)
                {
                    colorSwitch = (colorSwitch) ? false : true;
                }
                for (int j = 0; j < Cells.Length/t; j++)
                {
                    Cells[i, j] = new Cell(colorSwitch);

                    Cells[i, j].Fill = (Cells[i, j].Color) ? whiteRow : blackRow;

                    Cells[i, j].x_position = j * Cells[i, j].Fill.Length;

                    Cells[i, j].y_position = i * (Cell.Size);

                    //_userCommunication.PrintCell(Cells[i, j]);

                    colorSwitch = (colorSwitch) ? false : true;
                }
            }

            return Cells;
        }
    }
}
