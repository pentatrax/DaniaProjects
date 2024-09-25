using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Basisprogrammering___FlowControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pcTool;
            Tools pcChoice;
            Tools playerChoice;
            Winner winner = Winner.None;
            Language language = Language.English;
            string menuChoice = "";
            string[] rpsOptions = { "Rock", "Paper", "Scissor" };
            string[,] dialogue = { 
                {
                    "Welcome to Rock Paper Scissors.",
                    "Velkommen til Sten Saks Papir. "
                },
                {
                    "You play by using either Rock, Paper or Scissor and choosing the one that beats whatever your opponent chooses.",
                    "Du spiller ved at vælge enten Sten, Saks eller Papir og vinder ved at vælge den der slår hvad modstanderen vælger.",
                },
                {
                    "You have several options, what do you choose?",
                    "Du har forskellige muligheder, hvad vælger du?"
                },
                {
                    "Choice: ",
                    "Valg: "
                },
                {
                    "What language do you want to use? [Danish / English]: ",
                    "Hvilket sprog kunne du tænke dig at bruge? [Danish / English]: "
                },
                {
                    "Best out of 3.",
                    "Bedste ud af 3."
                },
                {
                    "What do you choose?: ",
                    "Hvad er dit valg?: "
                },
                {
                    "Rock, Paper, Scissor",
                    "Sten, Saks, Papir"
                },
                {
                    "It's a tie.",
                    "Ingen vandt."
                },
                {
                    "You've won!",
                    "Du vandt!"
                },
                {
                    "You lost!",
                    "Du har tabt!"
                },
                {
                    "The score is: ",
                    "Der står: "
                },
                {
                    "Press ENTER to return to menu.",
                    "Tryk på ENTER for at vende tilbage til menuen."
                },
                {
                    "Last choices were: ",
                    "Sidste valg var: "
                }
            };
            bool running = true;
            while (running) // Obligatorisk løkke
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(dialogue[0, (int)language]);
                Console.WriteLine(dialogue[1, (int)language]);
                Console.WriteLine(dialogue[2, (int)language]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Start");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(",");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Options");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(",");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Quit");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(dialogue[3, (int)language]);
                Console.ForegroundColor = ConsoleColor.White;
                menuChoice = Console.ReadLine();

                switch (menuChoice.ToLower()) 
                {
                    case "start":
                        winner = Winner.None;
                        byte playerWins = 0;
                        byte pcWins = 0;
                        string playerTool = "";
                        Random r = new Random();
                        Tools tool;
                        while (winner == Winner.None)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(dialogue[5, (int)language]);
                            Console.Write(dialogue[11, (int)language]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{playerWins} / {pcWins}");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if (pcWins >= 3 || playerWins >= 3)
                            {
                                Console.WriteLine(dialogue[12, (int)language]);
                                if (playerWins > pcWins)
                                {
                                    winner = Winner.Player;
                                } else
                                {
                                    winner = Winner.Pc;
                                }
                                
                            } else
                            {
                                Console.WriteLine(dialogue[7, (int)language]);
                                Console.Write(dialogue[6, (int)language]);
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            pcTool = r.Next(0, 3);
                            playerTool = Console.ReadLine();

                            switch (playerTool.ToLower())
                            {
                                case "rock":
                                    playerChoice = Tools.Rock;
                                    break;
                                case "paper":
                                    playerChoice = Tools.Paper;
                                    break;
                                case "scissor":
                                    playerChoice = Tools.Scissors;
                                    break;
                                case "sten":
                                    playerChoice = Tools.Rock;
                                    break;
                                case "papir":
                                    playerChoice = Tools.Paper;
                                    break;
                                case "saks":
                                    playerChoice = Tools.Scissors;
                                    break;
                                case "quit":
                                    running = false;
                                    winner = Winner.Pc;
                                    playerChoice = Tools.Rock;
                                    break;
                                default:
                                    playerChoice = Tools.Rock;
                                    break;
                            }
                            switch (pcTool) // Obligatorisk switch case. En smule redundant.
                            {
                                case 0:
                                    pcChoice = Tools.Rock;
                                    break;
                                case 1:
                                    pcChoice = Tools.Paper;
                                    break;
                                case 2:
                                    pcChoice = Tools.Scissors;
                                    break;
                                default:
                                    pcChoice = Tools.Rock;
                                    break;
                            }
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if ((int)playerChoice == (int)pcChoice) // Obligatorisk If-sætninger
                            {
                                Console.WriteLine(dialogue[8, (int)language]);
                            }
                            else if ((int)playerChoice > (int)pcChoice && !(pcChoice == Tools.Rock && playerChoice == Tools.Scissors) || (pcChoice == Tools.Scissors && playerChoice == Tools.Rock))
                            {
                                Console.WriteLine(dialogue[9, (int)language]);
                                playerWins += 1;
                            } else
                            {
                                Console.WriteLine(dialogue[10, (int)language]);
                                pcWins += 1;
                            }
                            Console.WriteLine(dialogue[13, (int)language] + $" {playerChoice}, {pcChoice}");
                        }
                        break;
                    case "options":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(dialogue[4, (int)language]);
                        Console.ForegroundColor = ConsoleColor.White;
                        string lChoice = Console.ReadLine();
                        switch (lChoice.ToLower())
                        {
                            case "danish":
                                language = Language.Danish;
                                break;
                            case "english":
                                language = Language.English;
                                break;
                        }
                        break;
                    case "quit":
                        running = false;
                        break;
                }
            }
        }
    }
}
