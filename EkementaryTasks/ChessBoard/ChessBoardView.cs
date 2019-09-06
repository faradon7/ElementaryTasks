using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class ChessBoardView : IChessBoardView
    {
        public string[] GetUserInput(string[] start)
        {
            string[] userInput = new string[start.Length];
            for (int i = 0; i < start.Length; i++)
            {
                Console.Write(start[i]);

                userInput[i] = Console.ReadLine();

            }

            return userInput;
        }

        public void PrintCell(Cell cell)
        {

            int MoveCoursor = cell.x_position;
            int LiftCoursor = cell.y_position;

            Console.SetCursorPosition(MoveCoursor, LiftCoursor);

            for (int i = 0; i < Cell.Size; i++)
            {
                Console.Write(cell);

                while (!(i == Cell.Size - 1))
                {
                    //MoveCoursor += cell.CellLength.Length;
                    //LiftCoursor = NextRow;
                    //Console.SetCursorPosition(MoveCoursor, LiftCoursor);
                    Console.SetCursorPosition(MoveCoursor, ++LiftCoursor);
                }
            }
        }
    }
}
