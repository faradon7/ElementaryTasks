using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class ChessBoard : IBoard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private int MoveCoursor = 0;
        private int LiftCoursor = 0;
        public int NextRow = 0;

        public Cell[,] Cells { get; set; }

        private IChessBoardView _userCommunication;

        public Cell this[int x, int y]
        {
            get
            {
                return Cells[x, y];
            }

            set
            {
                Cells[x, y] = value;
            }
        }

        public ChessBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new Cell[Rows, Columns];
        }

        public void GetBoard(int sizeOfCell)
        {
            bool colorSwitch = true;

            char[] whiteRow = new char[Cell.Size * 2];

            char[] blackRow = new char[Cell.Size * 2]; ;

            for (int i = 0; i < Cell.Size * 2; i++)
            {
                whiteRow[i] = ('█');

                blackRow[i] = (' ');
            }

            Cell.Size = sizeOfCell;

            for (LiftCoursor = 0; LiftCoursor < Rows * Cell.Size; LiftCoursor += Cell.Size)
            {
                for (MoveCoursor = 0; MoveCoursor < Cell.Length; MoveCoursor += Cell.Length)
                {
                    Cells[MoveCoursor, LiftCoursor].Color = (colorSwitch) ? false : true;

                    Cells[MoveCoursor, LiftCoursor].Fill = (Cells[MoveCoursor, LiftCoursor].Color) ? whiteRow : blackRow;

                    _userCommunication.PrintCell(Cells[MoveCoursor, LiftCoursor]);
                }

                //if (MoveCoursor == Columns)
                //{
                //    NextRow += CellSize;
                //    MoveCoursor = 0;
                //    LiftCoursor = NextRow;
                //    Console.SetCursorPosition(MoveCoursor, NextRow);
                //}

            }

        }
    }
}
