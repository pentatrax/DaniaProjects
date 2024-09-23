using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaniaProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            int num1 = 0;
            int num2 = 0;
            int sum = 0;
            string input1 = "";
            string input2 = "";
            char finalInput;
            do
            {
                Console.Clear();
                Console.WriteLine("Hello, World!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Type a number:");
                input1 = Console.ReadLine();
                Console.Beep(5000, 500);
                Console.WriteLine("Type a number to add:");
                input2 = Console.ReadLine();
                Console.Beep(2500, 500);
                if (input1 != "" && input2 != "")
                {
                    num1 = Convert.ToInt32(input1);
                    num2 = Convert.ToInt32(input2);
                }
                sum = num1 + num2;
                Console.Write("The sum of your numbers is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sum);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press ESC to close or ENTER to go again");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Environment.Exit(0);
        }
    }
}
