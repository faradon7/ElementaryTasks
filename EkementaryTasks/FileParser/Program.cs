using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using AdditionalClasses;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application(new ConsoleUI());
            app.AppStart();

            //StringReplacer rep = new StringReplacer(@"C:\Users\farik\EkementaryTasks\1.txt", "Завет", "обещание");

            //StringsCounter rep = new StringsCounter(@"C:\Users\farik\EkementaryTasks\Biblija.txt", "завет");

            //Console.WriteLine(rep.Replace());
            //Console.WriteLine("Finish");
            //Console.ReadLine();

        }
    }
}
