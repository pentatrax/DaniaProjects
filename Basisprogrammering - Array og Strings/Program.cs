using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Basisprogrammering___Array_og_Strings
{
    internal class Program
    {
        static void Log(object input)
        {
            Console.Write(input);
        }
        static void Log(object input, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.Write(input);
        }
        static void Log(object input, ConsoleColor foregroundColor, bool resetColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.Write(input);
            if (resetColor)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Log(object input, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(input);
        }
        static void Log(object input, ConsoleColor foregroundColor, ConsoleColor backgroundColor, bool resetColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(input);
            if (resetColor)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        static string GetRandomWordFromString(string wordList)
        {
            string word = "";
            string[] wordSplit = wordList.Split(',');
            Random r = new Random();
            int randomInt = r.Next(0, wordSplit.Length);
            word = wordSplit[randomInt];
            if (word.IndexOf(' ') != -1)
            {
                word = word.Remove(0, 1);
            }

            return word;
        }
        static string GetDialogue(string[,] dialogueList, DialogueKeys key, Language language)
        {
            string dialogue = "";

            dialogue = dialogueList[(int)key, (int)language];

            return dialogue;
        }
        static void DisplayHangman(int lifesRemaining, string word, int score, string guessedLetters)
        {
            Log(" ");
            for (int i=0; i < lifesRemaining; i++)
            {
                Log(" ");
                Log("<3", ConsoleColor.Red, true);
            }
            Log("\n\n ");
            for (int i = 0; i < word.Length; i++)
            {
                if (guessedLetters.IndexOf(word.ToLower()[i]) != -1)
                {
                    Log(" ");
                    Log(word.ToUpper()[i], ConsoleColor.Green, ConsoleColor.Black, true);
                }
                else
                {
                    Log(" ");
                    Log(" ", ConsoleColor.White, ConsoleColor.White, true);
                }
            }
        }
        static bool WordHasBeenGuessed(string word, string guesses)
        {
            bool wordHasBeenGuessed = false;
            int correctLetters = 0;

            for (int i=0; i < word.Length; i++)
            {
                if (guesses.ToLower().IndexOf(word.ToLower()[i]) != -1)
                {
                    correctLetters += 1;
                }
            }
            if (correctLetters == word.Length)
            {
                wordHasBeenGuessed = true;
            }

            return wordHasBeenGuessed;
        }
    static void Main(string[] args)
        {
            Language language = Language.English;
            string[] wordList = { 
                "equation, fish, admit, Koran, particle, train, fluctuation, relief, tool, audience, insure, assume, wealth, collect, representative, maze, lover, fun, overeat, shiver, cafe, dirty, cash, temporary, upset",
                "ligning, fisk, indrømme, Koranen, partikel, tog, udsving, lettelse, værktøj, publikum, forsikre, antage, rigdom, samle, repræsentativ, labyrint, elsker, sjovt, overspise, ryste, cafe, beskidt, kontanter, midlertidig, oprørt", 
            };
            string[,] dialogue =
            {
                {
                    "Welcome to Hangman!",
                    "Velkommen til Hangman!"
                },
                {
                    "Play",
                    "Spil"
                },
                {
                    "Language",
                    "Sprog"
                },
                {
                    "Quit",
                    "Afslut"
                },
                {
                    "What do you choose?: ",
                    "Hvad vælger du?: "
                },
                {
                    "We have generated a random word for you to guess.\ncarefull now, you only how a set amount of lifes.",
                    "Vi har genereret et tilfældigt ord, det er op til dig at gætte det.\nGætter du forkert for mange gange, løber du stille tør for liv."
                },
                {
                    "You can guess the word letter by letter or the entire word all together.",
                    "Man kan gætte ved at gå bogstav for bogstav, eller prøve at gætte hele ordet på en gang."
                },
                {
                    "Take a guess [A-Z]: ",
                    "Hvad gætter du [A-Å]?: "
                },
                {
                    "You've guessed these letters so far: ",
                    "Du har gættet på disse bogstaver indtil videre: "
                },
                {
                    "What language do you want to use [Dansk / English]?: ",
                    "Hvilket sprog kunne du tænke dig at bruge [Dansk / English]?: "
                },
                {
                    "Chosen option wasn't valid!",
                    "Dette valg er ugyldigt!"
                },
                {
                    "Points: ",
                    "Point: "
                },
                {
                    "The word was ",
                    "Ordet var "
                },
                {
                    "Better luck next time.",
                    "Håber det går bedre næste gang."
                },
                {
                    "Press any key to return to menu...",
                    "Tryk på hvilken som helst knap for at vende tilbage til menuen..."
                },
                {
                    "Congratulations you guessed the word ",
                    "Tillykke du har gættet ordet "
                },
                {
                    "Amount of guesses before you won: ",
                    "Antal gæt før du vandt: "
                }
            };
            string chosenWord = GetRandomWordFromString(wordList[(int)language]);
            string guessedLetters = "";
            string playerChoice = "";
            string errorMsg = "";
            bool running = true;
            bool justGuessedRight = false;
            ProgramState state = ProgramState.Menu;
            int points = 100;
            int lives = 10;
            while (running)
            {
                Console.Clear();
                if (errorMsg != "") Log(errorMsg + "\n", ConsoleColor.Red);
                switch (state)
                {
                    case ProgramState.Menu:
                        Log(GetDialogue(dialogue, DialogueKeys.Welcome, language), ConsoleColor.Yellow);
                        Log("\n\n[" + GetDialogue(dialogue, DialogueKeys.Play, language) + "]\n", ConsoleColor.Green);
                        Log("[" + GetDialogue(dialogue, DialogueKeys.Language, language) + "]\n", ConsoleColor.White);
                        Log("[" + GetDialogue(dialogue, DialogueKeys.Quit, language) + "]\n\n", ConsoleColor.Red);
                        Log(GetDialogue(dialogue, DialogueKeys.Choice1, language), ConsoleColor.Yellow, true);
                        playerChoice = Console.ReadLine().ToLower();

                        if (playerChoice == GetDialogue(dialogue, DialogueKeys.Play, language).ToLower())
                        {
                            chosenWord = GetRandomWordFromString(wordList[(int)language]);
                            guessedLetters = "";
                            lives = 10;
                            points = 100;
                            state = ProgramState.Play;
                            errorMsg = "";
                        }
                        else if (playerChoice == GetDialogue(dialogue, DialogueKeys.Language, language).ToLower())
                        {
                            state = ProgramState.Language;
                            errorMsg = "";
                        }
                        else if (playerChoice == GetDialogue(dialogue, DialogueKeys.Quit, language).ToLower())
                        {
                            state = ProgramState.Quit;
                        } else
                        {
                            errorMsg = GetDialogue(dialogue, DialogueKeys.InvalidOption, language);
                        }
                        break;
                    case ProgramState.Language:
                        Log(GetDialogue(dialogue, DialogueKeys.ChooseLanguage, language), ConsoleColor.Yellow, true);
                        playerChoice = Console.ReadLine().ToLower();
                        switch (playerChoice)
                        {
                            case "dansk":
                                language = Language.Danish;
                                state = ProgramState.Menu;
                                break;
                            case "english":
                                state = ProgramState.Menu;
                                language = Language.English;
                                break;
                            default:

                                errorMsg = GetDialogue(dialogue, DialogueKeys.InvalidOption, language);
                                break;
                        }
                        break;
                    case ProgramState.Play:
                        Log(GetDialogue(dialogue, DialogueKeys.ExplanationLifes, language)+"\n", ConsoleColor.Yellow);
                        Log(GetDialogue(dialogue, DialogueKeys.ExplanationHowToPlay, language)+"\n");
                        Log(GetDialogue(dialogue, DialogueKeys.WrongLetters, language));
                        Log(guessedLetters+"\n\n", ConsoleColor.Gray, true);
                        Log(GetDialogue(dialogue, DialogueKeys.Points, language), ConsoleColor.Yellow, true);
                        Log(points+"\n", ConsoleColor.Blue, true);
                        DisplayHangman(lives, chosenWord, points, guessedLetters);
                        Log("\n\n"+GetDialogue(dialogue, DialogueKeys.GuessALetter, language), ConsoleColor.Yellow, true);
                        playerChoice = Console.ReadLine().ToLower();

                        for (int i = 0; i < playerChoice.Length; i++)
                        {
                            if (guessedLetters.IndexOf(playerChoice[i]) == -1)
                            {
                                guessedLetters += playerChoice[i];
                            }

                            if (chosenWord.ToLower().IndexOf(playerChoice[i]) != -1)
                            {
                                if (justGuessedRight) {
                                    points += 25;
                                } else
                                {
                                    points += 15;
                                }
                                justGuessedRight = true;
                            }
                            else
                            {
                                lives -= 1;
                                points -= 20;
                            }
                        }
                        if (lives <= 0)
                        {
                            state = ProgramState.Lost;
                        }
                        if (WordHasBeenGuessed(chosenWord, guessedLetters))
                        {
                            state = ProgramState.Won;
                        }
                        break;
                    case ProgramState.Quit:
                        running = false;
                        Environment.Exit(0);
                        break;
                    case ProgramState.Won:
                        Log(GetDialogue(dialogue, DialogueKeys.Congrats, language), ConsoleColor.Yellow, true);
                        Log(chosenWord.ToUpper()+"\n", ConsoleColor.Green, true);
                        Log(GetDialogue(dialogue, DialogueKeys.BeforeYouWon, language), ConsoleColor.Yellow);
                        Log(guessedLetters.Length+"\n", ConsoleColor.White, true);
                        Log(GetDialogue(dialogue, DialogueKeys.PressAnyKey, language), ConsoleColor.Gray, true);
                        Console.ReadKey();
                        state = ProgramState.Menu;
                        break;
                    case ProgramState.Lost:
                        Log(GetDialogue(dialogue, DialogueKeys.WordWas, language), ConsoleColor.Yellow);
                        Log(chosenWord.ToUpper() + ".\n", ConsoleColor.Green);
                        Log(GetDialogue(dialogue, DialogueKeys.BetterLuck, language)+"\n", ConsoleColor.Yellow);
                        Log(GetDialogue(dialogue, DialogueKeys.PressAnyKey, language), ConsoleColor.Gray);
                        Console.ReadKey();
                        state = ProgramState.Menu;
                        break;
                }
            }
        }
    }
}
