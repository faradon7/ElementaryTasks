using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows;
            int columns; 

            Console.Write("Введите количество клеток по высоте: ");

            var isParsedRows = int.TryParse(Console.ReadLine(), out rows);

            Console.Write("Введите количество клеток по ширине: ");
           
            var isParsedColumns = int.TryParse(Console.ReadLine(), out columns);

            if (!(isParsedRows && isParsedColumns))
            {
                rows = 8;
                columns = 8;
            }

            Console.Clear();

            ChessBoard ch = new ChessBoard();
            ch.GetTheBoard(rows, columns);
            
            Console.ReadKey();
        }
    } 
}
      