using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ESC");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" to close App or write anything and hit ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" to log text");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.WriteLine(Console.ReadLine());
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Environment.Exit(0);
        }
    }
}
