using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Basisprogrammering___Variabler___Datatyper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            byte rndNumber = 0;
            byte guess = 0;
            string playerName = "";
            byte triesUsed = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("What's your name?: ");
                Console.ForegroundColor = ConsoleColor.White;
                playerName = Console.ReadLine();
                Console.Clear();
                rndNumber = Convert.ToByte(rnd.Next(0, 100));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Hello ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(playerName);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(", nice to meet you.");
                Console.Write("I've generated a number between 0 and 100 what is it?: ");
                while (guess != rndNumber)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    guess = Convert.ToByte(Console.ReadLine());
                    triesUsed += 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (guess < rndNumber)
                    {
                        Console.Write("Your guess was off by ");
                        Console.WriteLine(rndNumber - guess);
                        Console.Write("What's the number?: ");
                    }
                    if (guess > rndNumber)
                    {
                        Console.Write("Your guess was off by ");
                        Console.WriteLine(guess - rndNumber);
                        Console.Write("What's the number?: ");
                    }
                }
                Console.WriteLine($"Congrats you guessed the number after {triesUsed} guesses!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("To play again press ENTER, to quit press ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
