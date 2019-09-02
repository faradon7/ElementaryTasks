using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace NumericalSequence
{
    class Program
    {
        public static NaturalNumbers NaturalNumbers { get; } = new NaturalNumbers();

        public static IUserCommunication UserCommunication { get ; set; } = new ConsoleUI();

        static void Main(string[] args)
        {

            NaturalNumbers.GetSequense(UserCommunication);

        }

        
                            
    }
}
