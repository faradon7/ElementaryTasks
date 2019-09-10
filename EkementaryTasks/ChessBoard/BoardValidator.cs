using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace ChessBoard
{
    class ChessBoardValidator : INumberValidator
    {
        public bool IsValidNumbers(int[] boardOptions)
        {
            return !(boardOptions[0] > 8 | boardOptions[1] > 8);
        }
    }
}
