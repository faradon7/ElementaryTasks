using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MyLibrary
{
    public class ConsoleUI : IUserCommunication
    {
        public string GetUserInput()
        {
            string userInput;
                Console.Write("Enter natural number: ");

                userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                userInput = string.Empty;
            }
            return userInput;
        }

        public void Output(double sequenceMember)
        {
            Console.Write(sequenceMember);
            Console.Write(", ");
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public void Output(StringBuilder sb)
        {
            Console.WriteLine(sb);
        }

        public void Print(IEnumerable row)
        {
            foreach (var item in row)
            {
                Console.Write(item);
                Console.Write(", ");
            }
        }
        
    }
}
