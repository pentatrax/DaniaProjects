using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse1_03_Functions
{
    internal class Program
    {
        static void Aloha()
        {
            Console.WriteLine("Aloha");
        }

        /// <summary>
        /// Takes a input and writes it to console.
        /// A short hand for Console.WriteLine().
        /// </summary>
        /// <param name="input"></param>
        static void Log(Object input)
        {
            Console.WriteLine(input);
        }

        static string GetText()
        {
            return "Hello World!";
        }

        static double Math(double firstNumber, char operation, double secondNumber)
        {
            double sum = 0;

            switch (operation)
            {
                case '+':
                    sum = firstNumber + secondNumber;
                    break;
                case '-':
                    sum = firstNumber - secondNumber;
                    break;
                case '*':
                    sum = firstNumber * secondNumber;
                    break;
                case '/':
                    sum = firstNumber / secondNumber;
                    break;
                case '%':
                    sum = firstNumber % secondNumber;
                    break;

            }

            return sum;
        }

        static double Formula(double x, double b, double y)
        {
            double sum = 0;

            sum = (x + b * 10) / y;

            return sum;
        }
        static void Main(string[] args)
        {
            Aloha();
            Log("");
            Log("Hi worldo.");
            Log("");
            Log(GetText());
            Log("");
            Log("Math(18, '+', 55);");
            Log(Convert.ToString(Math(18, '+', 55)));
            Log("");
            Log("Math(18, '-', 55);");
            Log(Convert.ToString(Math(18, '-', 55)));
            Log("");
            Log("Math(18, '*', 55);");
            Log(Convert.ToString(Math(18, '*', 55)));
            Log("");
            Log("Math(18, '/', 55);");
            Log(Convert.ToString(Math(18, '/', 55)));
            Log("");
            Log("Math(18, '%', 55);");
            Log(Math(18, '%', 55));
            Log("");
            Log("(x+b*10)/y");
            Log("(2.5+5*10)/10");
            Log(Formula(2.5, 5, 10));

            Console.ReadKey();
        }
    }
}
