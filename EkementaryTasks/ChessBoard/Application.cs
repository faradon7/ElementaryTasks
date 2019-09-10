using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Interfaces;

namespace ChessBoard
{
    class Application
    {
        private INumberParser _parser = new Parser();

        private INumberValidator _validator = new Validator();

        public IBoard ChessBoard { get; set; }

        private IChessBoardView _userCommunication;

        public Application(IChessBoardView ui)
        {
            _userCommunication = ui;
        }

        public void ApStart()
        {
            bool wantToContinue = false;
            do
            {
                int rows;

                int columns;

                bool isExtracted = false;

                string[] arqs;

                int[] boardOptions;

                arqs = _userCommunication.GetUserInput(new[] { "Enter amount of board rows: ", "Enter amount of board columns: " });

                boardOptions = _parser.ExtractDigits(arqs, out isExtracted);

                _validator.IsValidNumbers(boardOptions);

                rows = (int)boardOptions[0];

                columns = (int)boardOptions[1];

                ChessBoard = new ChessBoard(rows, columns, _userCommunication);

                _userCommunication.PrintBoard(ChessBoard);

                wantToContinue =  _userCommunication.WantContinue();

            } while (wantToContinue);

            Environment.Exit(0);
        }

    }
}
