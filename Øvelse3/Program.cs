using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mailer[] arr_mailers = new Mailer[0];
            AppState state = AppState.StartMenu;
            string option = "";
            Mailer temp_mailer = new Mailer("", "", 0, "", 0, "", "", "");
            do
            {
                switch (state)
                {
                    case AppState.StartMenu:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("===============================================================================");
                        Console.Write("||     ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Welcome to the postal App.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("||     ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press ESC to exit the App.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("||     ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("(C)reate new user.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("||     ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("(E)dit old user.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("||     ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("(L)ist all users.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("===============================================================================");
                        Console.Write("Choose an action [Default: C]: ");
                        option = Console.ReadLine();
                        if (option == "C" || option == "c")
                        {
                            state = AppState.NewUserInfo;
                        }
                        if (option == "E" || option == "e")
                        {
                            state = AppState.EditOldUser;
                        }
                        if (option == "L" || option == "l")
                        {
                            state = AppState.ListUsers;
                        }
                        break;
                    case AppState.NewUserInfo:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("First name: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp_mailer.set_firstName(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Last name: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp_mailer.set_lastName(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Age: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp_mailer.set_age(Convert.ToInt32(Console.ReadLine()));
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Address [Street and House Nr.]: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp_mailer.set_address(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Postal Code [####]: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp_mailer.set_postalCode(Convert.ToInt32(Console.ReadLine()));
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("City: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp_mailer.set_city(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Country: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp_mailer.set_country(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("E-Mail [name@host.com]: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        temp_mailer.set_email(Console.ReadLine());
                        arr_mailers.Append(temp_mailer);
                        break;
                    case AppState.EditOldUser:
                        break;
                    case AppState.ListUsers:
                        break;
                    default:
                        Environment.Exit(1);
                        break;
                } 
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Environment.Exit(0);
        }
    }
}
