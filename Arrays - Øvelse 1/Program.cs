using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays___Øvelse_1
{
    internal class Program
    {
        /// <summary>
        /// Shorthand for Console.Write().
        /// </summary>
        /// <param name="input">Object that should be written into the console.</param>
        static void Log(Object input)
        {
            Console.Write(input);
        }
        static void Color(ConsoleColor c)
        {
            Console.ForegroundColor = c;
        }
        static int[] ChangeArrayItem(int[] array, out string errorMsg)
        {
            int[] temp = array;
            errorMsg = "";
            string choice = "";
            int convChoice = 0;
            int convChoice2 = 0;
            Color(ConsoleColor.Yellow);
            Log("What index should we change?: ");
            Color(ConsoleColor.White);
            choice = Console.ReadLine();
            convChoice = Convert.ToInt32(choice);
            if (convChoice < array.Length - 1)
            {
                Color(ConsoleColor.Yellow);
                Log("What would you like to change the value [");
                Color(ConsoleColor.White);
                Log(temp.GetValue(convChoice));
                Color(ConsoleColor.Yellow);
                Log("] to?: ");
                Color(ConsoleColor.White);
                choice = Console.ReadLine();
                convChoice2 = Convert.ToInt32(choice);
                temp.SetValue(convChoice2, convChoice);

            } else
            {
                errorMsg = "Choice is out of bounds for given array!";
            }

            return temp;
        }
        static string[] ChangeArrayItem(string[] array, out string errorMsg)
        {
            string[] temp = array;
            string choice = "";
            errorMsg = "";
            int convChoice = 0;
            Color(ConsoleColor.Yellow);
            Log("What index should we change?: ");
            Color(ConsoleColor.White);
            choice = Console.ReadLine();
            convChoice = Convert.ToInt32(choice);
            if (convChoice < array.Length - 1)
            {
                Color(ConsoleColor.Yellow);
                Log("What would you like to change the value [");
                Color(ConsoleColor.White);
                Log(temp.GetValue(convChoice));
                Color(ConsoleColor.Yellow);
                Log("] to?: ");
                Color(ConsoleColor.White);
                choice = Console.ReadLine();
                temp.SetValue(choice, convChoice);

            }
            else
            {
                errorMsg = "Choice is out of bounds for given array!";
            }

            return temp;
        }
        static int[] AddArrayItem(int[] array)
        {
            string choice = "";
            int[] temp = new int[array.Length + 1];
            for (int i=0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            Color(ConsoleColor.Yellow);
            Log("What value would you like to add?: ");
            Color(ConsoleColor.White);
            choice = Console.ReadLine();
            temp[temp.Length - 1] = Convert.ToInt32(choice);

            return temp;
        }
        static string[] AddArrayItem(string[] array)
        {
            string choice = "";
            string[] temp = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            Color(ConsoleColor.Yellow);
            Log("What value would you like to add?: ");
            Color(ConsoleColor.White);
            choice = Console.ReadLine();
            temp[temp.Length - 1] = choice;

            return temp;
        }

        static void Main(string[] args)
        {
            bool firstRun = true;
            bool running = true;
            string error = "";
            string usrChoice = "";
            int[] numbers = { 12, 33, 532, 145, 1, 4565, 1 };
            string[] names = { "Philip", "Rikker", "Simon", "Lasse", "Emilie", "Silas", "Julius", "Malthe", "Markus", "Mark"};
            while (running)
            {
                // Øvelse1 Grøn
                Color(ConsoleColor.Yellow);
                Log(numbers[4]);
                if (firstRun) numbers[2] = 36562;
                Log("\n\nForeach numbers\n");
                Color(ConsoleColor.White);
                foreach (int nr in numbers)
                {
                    Log(nr + ", ");
                }
                Color(ConsoleColor.Yellow);
                Log("\n\nFor numbers\n");
                Color(ConsoleColor.White);
                for (int i = 0; i < numbers.Length; i++)
                {
                    Log(numbers[i] + ", ");
                }
                Color(ConsoleColor.Yellow);
                Log("\n\n\n");
                Log(names[4]);
                if (firstRun) names[2] = "Mario";
                Color(ConsoleColor.Yellow);
                Log("\n\nForeach names\n");
                Color(ConsoleColor.White);
                foreach (var name in names)
                {
                    Log(name + ", ");
                }
                Color(ConsoleColor.Yellow);
                Log("\n\nFor names\n");
                Color(ConsoleColor.White);
                for (int i = 0; i < names.Length; i++)
                {
                    Log(names[i] + ", ");
                }

                // Øvelse1 Gul
                Color(ConsoleColor.Yellow);
                Log("\n\n\nWhat would you like to do [Change / Add] value or [Quit]?: ");
                Color(ConsoleColor.White);
                usrChoice = Console.ReadLine();
                switch (usrChoice.ToLower())
                {
                    case "change":
                        Color(ConsoleColor.Yellow);
                        Log("What array would you like to change?: ");
                        Color(ConsoleColor.White);
                        usrChoice = Console.ReadLine();
                        switch (usrChoice.ToLower())
                        {
                            case "numbers":
                                numbers = ChangeArrayItem(numbers, out error);
                                break;
                            case "names":
                                names = ChangeArrayItem(names, out error);
                                break;
                            case "quit":
                                running = false;
                                break;
                            default:
                                error = "That array doesn't exist!";
                                break;
                        }
                        break;
                    case "add":
                        Color(ConsoleColor.Yellow);
                        Log("What array would you like to add a value to?: ");
                        Color(ConsoleColor.White);
                        usrChoice = Console.ReadLine();
                        switch (usrChoice.ToLower())
                        {
                            case "numbers":
                                numbers = AddArrayItem(numbers);
                                break;
                            case "names":
                                names = AddArrayItem(names);
                                break;
                            case "quit":
                                running = false;
                                break;
                            default:
                                error = "That array doesn't exist!";
                                break;
                        }
                        break;
                    case "quit":
                        running = false;
                        break;
                    default:
                        error = "That option is invalid!";
                        break;
                }

                Console.Clear();
                if (error != "")
                {
                    Color(ConsoleColor.Red);
                    Log(error + "\n\n");
                    error = "";
                }

                firstRun = false;
            }
        }
    }
}
