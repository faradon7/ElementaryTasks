using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdditionalClasses;

namespace ChessBoard
{
    class ChessBoardView : IChessBoardView
    {
        public void PrintInstructions(StringBuilder sb)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sb);
            Console.ResetColor();
        }

        public void Message(string message)
        {
            Console.Write(message);
        }

        public void Warning(string message)
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);

            Console.ResetColor();
        }

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

        public string GetUserInput(string start)
        {
            string userInput;

            Console.Write(start);

            userInput = Console.ReadLine();

            return userInput;
        }

        public void PrintBoard(IBoard board)
        {
            Console.Clear();

            foreach (var cell in board.Cells)
            {
                int MoveCoursor = cell.x_position;

                int LiftCoursor = cell.y_position;

                Console.SetCursorPosition(cell.x_position, cell.y_position);

                for (int i = 0; i < Cell.Size; i++)
                {
                        Console.Write(cell.Fill);
                        Console.SetCursorPosition(MoveCoursor, ++LiftCoursor);
                }
            }
        }

        public bool WantContinue()
        {
            Console.WriteLine();

            string resp = GetUserInput(StringsConstants.wantContinue).ToUpper();

            return (resp == "YES" | resp == "Y");

        }
    }
}
