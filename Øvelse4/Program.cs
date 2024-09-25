using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double oldResult = 0;
            String bigOppearation = "";
            do
            {
                double num1 = 0;
                double num2 = 0;
                double result = oldResult;
                Console.Clear();
                // Get user inputs
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (result == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter first number [##,##]: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter opperation [/,*,+,-,%]: ");
                }
                else
                {
                    Console.Write("Enter opperation [*=,+=,-=,/=,%=]: ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                string symbol = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter second number [##,##]: ");
                Console.ForegroundColor = ConsoleColor.White;
                num2 = Convert.ToDouble(Console.ReadLine());

                // Do calculation
                switch (symbol)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        result = num1 / num2;
                        break;
                    case "%":
                        result = num1 % num2;
                        break;
                    case "*=":
                        result = result * num2;
                        break;
                    case "-=":
                        result -= num2;
                        break;
                    case "+=":
                        result += num2;
                        break;
                    case "%=":
                        result = result % num2;
                        break;
                    case "/=":
                        result = result / num2;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: A non existent oppration was chosen!");
                        break;
                }

                //Display result
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("The result of ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{num1} {symbol} {num2}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" is ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result}.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");

                Console.WriteLine("Would you like to add a opperation to the result? [Y/N]");
                string answer = Console.ReadLine();
                if (answer == "Y" || answer == "y")
                {
                    oldResult = result;
                } else
                {
                    oldResult = 0;
                }
             
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
