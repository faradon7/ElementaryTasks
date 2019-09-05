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

            //StringsCounter s = new StringsCounter();

            StringReplacer rep = new StringReplacer(@"C:\Users\farik\EkementaryTasks\1.txt", "Завет", "обещание");



            //Stream stream = File.OpenRead(@"C:\Users\farik\EkementaryTasks\Biblija.txt");

            //rep.stream = new StreamReader(stream, Encoding.UTF8, true, 10240);

            //StringsCounter rep = new StringsCounter(@"C:\Users\farik\EkementaryTasks\Biblija.txt", "завет");

            //rep.Count();
            Console.WriteLine(rep.Replace());
            Console.WriteLine("Finish");
            Console.ReadLine();

        }
    }
}
