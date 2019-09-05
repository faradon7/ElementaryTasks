using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Application app = new Application(new ConsoleUI());
            //app.AppStart();


            //ReverseLineReader rev = new ReverseLineReader(@"C:\Users\farik\EkementaryTasks\Biblija.txt");

            //int dogsCounter = 0;

            //foreach (var item in rev)
            //{
            //    if (item.ToLowerInvariant().Contains("dogs"))
            //    {
            //        dogsCounter++;
            //        Console.WriteLine(item.ToLowerInvariant().Replace("dogs", "cats"));
            //    }
            //    else
            //    {
            //        Console.WriteLine(item);
            //    }
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(dogsCounter);

            StringsCounter s = new StringsCounter();

            Stream stream = File.OpenRead(@"C:\Users\farik\EkementaryTasks\Biblija.txt");

            s.stream = new StreamReader(stream, Encoding.UTF8, true, 10240);

            int amount = 0;

            s.entry = "завет";

            foreach (var item in s)
            {
                amount += item;
            }
            Console.WriteLine(amount);
            Console.ReadLine();

        }
    }
}
