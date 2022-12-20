using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application(new ChessBoardView());
            application.ApStart();
        }
    }
}
