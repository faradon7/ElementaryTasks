using System;
using System.Collections.Generic;
using System.Linq;
using AdditionalClasses;
using Interfaces;

namespace FileParser
{
    class Application
    {
        private IValidator _validator = new Validator();

        private IFileParserView _userCommunication;

        public Application(IFileParserView ui)
        {
            _userCommunication = ui;
        }

        public void AppStart()
        {
            Enum mode = _userCommunication.ChooseMode("Count the number of string entries or replace all string entries? [Count/Replace] ");



            //switch (mode) // можно и ifами
            //{
            //    case UserResponse.Count:
            //        {
            //            StringsCounter counter = new StringsCounter();
            //            break;
            //        }
            //    case UserResponse.Replace:
            //        {
            //            StringReplacer replacer = new StringReplacer();
            //            break;
            //        }
            //    case UserResponse.Exit:
            //        {
            //            _userCommunication.WantContinue();
            //            break;
            //        }

            //}
        }
    }
}
