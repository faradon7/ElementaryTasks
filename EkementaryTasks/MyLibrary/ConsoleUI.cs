using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ConsoleUI : IUserCommunication
    {
        public string GetUserInput(string start)
        {
            string userInput;

            Console.Write(start);

            userInput = Console.ReadLine();

            //if (string.IsNullOrWhiteSpace(userInput))
            //{
            //    userInput = string.Empty;
            //}
            return userInput;
        }

        public void Output(double sequenceMember)
        {
            Console.Write(sequenceMember);
            Console.Write(", ");
        }

        public void Message(string message)
        {
            Console.Write(message);
        }

        public void Output(StringBuilder sb)
        {
            Console.WriteLine(sb);
        }

        public void Print(IEnumerable row)
        {
            Console.WriteLine();
            foreach (var item in row)
            {
                Console.Write(item);
                Console.Write(", ");
            }
        }

        public bool WantContinue()
        {
            Console.WriteLine();

            string resp = GetUserInput(StringsConstants.wantContinue).ToUpper();

            return (resp == "YES" | resp == "Y");

        }

    }
}
