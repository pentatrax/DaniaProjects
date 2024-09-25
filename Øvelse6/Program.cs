using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse6
{
    internal class Program
    {
        static void run(Dictionary<string, string> users)
        {
            int age = 0;
            string passwd = "";
            string inputPasswd = "";
            string inputUsrName = "";
            bool accessGranted = false;
            string denialMessage = "";
            string language = "english";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("How old are you?: ");
            Console.ForegroundColor = ConsoleColor.White;
            age = (age == 0) ? Convert.ToInt32(Console.ReadLine()) : age;
            if (age >= 18)
            {
                    Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Username: ");
                Console.ForegroundColor = ConsoleColor.White;
                inputUsrName = Console.ReadLine();
                    if (users.TryGetValue(inputUsrName, out passwd))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Password: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        inputPasswd = Console.ReadLine();
                        if (inputPasswd == passwd)
                        {
                            accessGranted = true;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("What is your prefered language? [Dansk/English]: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            language = Console.ReadLine();
                        }
                        else
                        {
                            denialMessage = "Wrong password!";
                        }
                    }
                    else
                    {
                        denialMessage = "User doesn't exist!";
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("User doesnt exist, would you like to Sign Up? [Y/N]: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        inputUsrName = Console.ReadLine();
                        switch (inputUsrName.ToUpper())
                        {
                            case "Y":
                                denialMessage = "Press ENTER to login.";
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("What is your username gonna be?: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                inputUsrName = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("What password will you use?: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                inputPasswd = Console.ReadLine();
                                users.Add(inputUsrName, inputPasswd);
                                break;
                            case "N":
                                break;
                            default:
                                denialMessage = "Unknown input!";
                                break;
                        }
                    }
            } else
            {
                denialMessage = "You are not old enough to use this service!";
            }
            if (accessGranted)
            {
                switch (language.ToUpper())
                    {
                        case "DANSK":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Velkommen {inputUsrName}, til servicen.");
                            Console.WriteLine($"Du er {age} år gammel.");
                            break;
                        case "ENGLISH":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Welcome {inputUsrName}, to the service.");
                            Console.WriteLine($"You are {age} years old.");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Welcome {inputUsrName}, to the service.");
                            Console.WriteLine($"You are {age} years old.");
                            break;
                    }
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(denialMessage);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press ESC to Quit.");
        }
        static void Main(string[] args)
        {
            int age = 0;
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("admin", "admin");
        do {
            run(users);
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
        }
    }
}
