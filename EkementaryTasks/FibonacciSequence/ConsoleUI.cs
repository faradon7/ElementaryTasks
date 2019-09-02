using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace FibonacciSequence
{
    class ConsoleUI : IUserCommunication
    {
        public string GetUserInput()
        {
            string userInput;
            Console.WriteLine("Enter the range of Fibonacci sequence");
            Console.WriteLine("From:");
            userInput = Console.ReadLine();

            Console.WriteLine("To:");

            userInput += " " + Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                userInput = string.Empty;
            }
            return userInput;
        }

        public void Message(string message)
        {
            throw new NotImplementedException();
        }

        public void Output(double a)
        {
            throw new NotImplementedException();
        }

        public void Output(StringBuilder sb)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable collection)
        {
            throw new NotImplementedException();
        }
    }
}
