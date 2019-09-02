using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace FibonacciSequence
{
    class Agregate
    {
        private IUserCommunication userCommunication { get; set; }

        private Counter counter = new Counter(); 
        public Agregate(IUserCommunication UI)
        {
            userCommunication = UI;
        }

        public void Run()
        {
            userCommunication.GetUserInput
        }

    }
}
