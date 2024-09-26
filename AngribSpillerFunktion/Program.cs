using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AngribSpillerFunktion
{
    internal class Program
    {
        static bool AttackPlayer(int playerAC, out int dmg)
        {
            bool hitWasSuccess = false;
            dmg = 0;
            Random r = new Random();
            int potentialDmg = r.Next(1, 7);
            int random = r.Next(1, 21);
            if (random > playerAC)
            {
                hitWasSuccess = true;
                if (random == 20)
                {
                    dmg = potentialDmg*2;
                } else
                {
                    dmg = potentialDmg;
                }
            }

            return hitWasSuccess;
        }

        static void Main(string[] args)
        {
            int playerHealth = 250;
            int playerAC = 14;
            int damageTaken = 0;
            while (playerHealth > 0)
            {
                if (AttackPlayer(playerAC, out damageTaken))
                {
                    playerHealth -= damageTaken;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("You've taken ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(damageTaken);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" damage, you have ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(playerHealth);
                    Console.Write(" HP ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" remaining.");
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("The hit missed.");
                }
                Thread.Sleep(500);
            }
            Console.ReadKey();
        }
    }
}
