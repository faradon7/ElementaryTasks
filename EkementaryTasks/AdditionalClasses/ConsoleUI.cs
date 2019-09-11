using System;
using System.Collections;
using System.Text;
using Interfaces;
using FileParser;

namespace Helpers
{
    public enum MessageType
    {
        Instructions,
        Remark,
        Warning,
        Default
    }
    public class ConsoleUI : IUserCommunication, IFileParserView
    {
        public string GetUserInput(string start)
        {
            string userInput;

            Console.Write(start);

            userInput = Console.ReadLine();

            return userInput;
        }

        public string[] GetUserInput(string[] start)
        {
            string[] userInput = new string[start.Length];
            for (int i = 0; i < start.Length; i++)
            {
                Console.Write(start[i]);

                userInput[i] = Console.ReadLine();

            }

            return userInput;
        }

        public void Message(string message)
        {
            Console.Write(message);
        }
        public void MessageLn(string message)
        {
            Console.WriteLine(message);
        }

        public void Output(StringBuilder sb)
        {
            Console.WriteLine(sb);
        }

        public void PrintArqs(int[] args)
        {
            StringBuilder s = new StringBuilder("from ");
            s.Append(args[0]);
            s.Append(" to ");
            s.Append(args[1]);
            Console.WriteLine(s);

        }

        public void Print(int i)
        {
            
            Console.Write(i);
        }

        public void PrintInstructions(StringBuilder sb)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sb);
            Console.ResetColor();
        }

        public bool WantContinue()
        {
            Console.WriteLine();

            string resp = GetUserInput(StringsConstants.wantContinue).ToUpper();

            return (resp == "YES" | resp == "Y");

        }

        public void Warning(string message)
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);

            Console.ResetColor();
        }

        public Enum ChooseMode(string question)
        {
            string resp = GetUserInput(question).ToUpper();

            switch (resp)
            {
                case ("C"):
                    {
                        return UserResponse.Count;
                    }
                case ("COUNT"):
                    {
                        return UserResponse.Count;
                    }
                case ("R"):
                    {
                        return UserResponse.Replace;
                    }
                case ("REPLACE"):
                    {
                        return UserResponse.Replace;
                    }

                default:
                    return UserResponse.Exit;
            }
        }
    }
}
