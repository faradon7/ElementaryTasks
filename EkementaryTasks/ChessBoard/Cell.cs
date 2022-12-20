using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class Cell
    {
        public char[] Fill;

        public bool Color;

        public static int Size { get; set; }

        public static int Length {get; set;}

        public Figure Figure { get; set; }

        public int x_position = 0;

        public int y_position = 0;

        public Cell(bool color, int size = 6)
        {
            Size = size;
            Length = Size * 2;
            Color = color;
        }

        public void SetFigureThere()
        {
            Console.SetCursorPosition(x_position-Length/2, y_position-Size/2);
        }

    }
}
