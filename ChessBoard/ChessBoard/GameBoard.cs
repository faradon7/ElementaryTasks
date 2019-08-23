using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    abstract class GameBoard
    {
        private char[] BlackCell;
        private char[] WhiteCell;

        public char[] GameFigures { get; set; }

        private int MoveCoursor = 0;
        private int LiftCoursor = 0;
        public int NextRow = 0;
        private int CellSize { get; set; }


        public void setCellSize(int size)
        {
            //size of cell validation
            if (size > 7)
            {
                CellSize = 7;
            }
            else if (size < 1)
            {
                CellSize = 1;
            }
            else
            { 
                CellSize = size;
            }

            char[] wCell = new char[CellSize * 2];
            char[] bCell = new char[CellSize * 2];
            for (int i = 0; i < CellSize * 2; i++)
            {
                wCell[i] = ('█');
                bCell[i] = (' ');
            }
            WhiteCell = wCell;
            BlackCell = bCell;
        }


        public void GetTheBoard()
        {
            Console.WriteLine("Задайте высоту и ширину доски!");
            Console.WriteLine("При необходимости задайте размер клетки от 1 до 8");
        }

        public void GetTheBoard(int rows, int columns)
        {
            setCellSize(6);

            for (int i = 0; i < rows; i++)
            {
                int j;

                for (j = 0; j < columns; j++)
                {
                    ColorAlteration(i, j);
                }

                if (j == columns)
                {
                    NextRow += CellSize;
                    MoveCoursor = 0;
                    LiftCoursor = NextRow;
                    Console.SetCursorPosition(MoveCoursor, NextRow);
                }

            }
        }

        public void GetTheBoard(int rows, int columns, int size)
        {
            setCellSize(size);
            GetTheBoard(rows, columns);
        }

        public void ColorAlteration(int i, int j)
        {
            if (i % 2 == 0)
            {
                if (j % 2 == 0)
                {
                    PrintCell(WhiteCell);
                }
                else
                {
                    PrintCell(BlackCell);
                }
            }
            else
            {
                if (j % 2 == 0)
                {
                    PrintCell(BlackCell);
                }
                else
                {
                    PrintCell(WhiteCell);
                }
            }
            
        }
        public void PrintCell(char[] cell)
        {
            for (int i = 0; i < CellSize; i++)
            {
               Console.Write(cell);

               if (i == CellSize - 1)
                {
                    MoveCoursor += cell.Length;
                    LiftCoursor = NextRow;
                    Console.SetCursorPosition(MoveCoursor, LiftCoursor);
                }
                else
                {
                    Console.SetCursorPosition(MoveCoursor, ++LiftCoursor);
                }
            }
        }
    }
}
