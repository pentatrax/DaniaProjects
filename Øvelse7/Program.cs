using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Øvelse7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string race = "";
            string classes = "";
            string factions = "";
            string finalCharacter = "Young ";
            string characterName = "";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("There are many races in this world of splendor - ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Orc, Elf, Human, Dwarf and Hobbit.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("What race is your character?: ");
            Console.ForegroundColor = ConsoleColor.White;
            race = Console.ReadLine();
            switch (race.ToUpper())
            {
                case "ORC":
                    finalCharacter += "dark hero, ";
                    classes = "Shaman, Brute, Warrior, Ranger";
                    factions = "Stormfront, Darkworld";
                    break;
                case "ELF":
                    finalCharacter += "hero of light, ";
                    classes = "Archer, Assassin, Ranger, Druid";
                    factions = "Yggdrasil, Forestchild";
                    break;
                case "HUMAN":
                    finalCharacter += "hero, ";
                    classes = "Fighter, Archer, Swordsman, Mage";
                    factions = "Eldon, Merccor";
                    break;
                case "DWARF":
                    finalCharacter += "stone, ";
                    classes = "Blacksmith, Tank, Weaponsmaster, Gunslinger";
                    factions = "Blackrock, Lavafell";
                    break;
                case "HOBBIT":
                    finalCharacter += "wanderer, ";
                    classes = "Druid, Merchant, Rogue, Cannonfodder";
                    factions = "Burrow, Hills";
                    break;
                default:
                    finalCharacter += "sullied, ";
                    race = "Void";
                    classes = "Cannonfodder, Slumdweller";
                    factions = "None";
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Well then little {race.ToUpper()}, what profession calls to you?");
            Console.Write("There are several fit for you. [");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(classes);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.White;
            classes = Console.ReadLine();
            finalCharacter += "your weapons consist of ";
            switch (classes.ToUpper())
            {
                case "CANNONFODDER":
                    finalCharacter += "sticks and rags.";
                    break;
                case "SLUMDWELLER":
                    finalCharacter += "bricks and knifes.";
                    break;
                case "SHAMAN":
                    finalCharacter += "your staff and magic.";
                    break;
                case "BRUTE":
                    finalCharacter += "your fists and trophies from battles gone.";
                    break;
                case "WARRIOR":
                    finalCharacter += "a sword and shield.";
                    break;
                case "RANGER":
                    finalCharacter += "daggers and blowdarts.";
                    break;
                case "ARCHER":
                    finalCharacter += "your trusty bow and arrows.";
                    break;
                case "ASSASSIN":
                    finalCharacter += "poisons and daggers";
                    break;
                case "DRUID":
                    finalCharacter += "a really large stick and nature.";
                    break;
                case "FIGHTER":
                    finalCharacter += "fists, swords and whatever you can get your hands on.";
                    break;
                case "SWORDSMAN":
                    finalCharacter += "two long swords, one for each hand.";
                    break;
                case "MAGE":
                    finalCharacter += "magic and magic accessories.";
                    break;
                case "BLACKSMITH":
                    finalCharacter += "your trusty hammer.";
                    break;
                case "TANK":
                    finalCharacter += "your strong shield and heavy gauntlets";
                    break;
                case "WEAPONSMASTER":
                    finalCharacter += "any weapon you can get your hands on.";
                    break;
                case "GUNSLINGER":
                    finalCharacter += "a genuine set of revolvers (cannons).";
                    break;
                case "MERCHANT":
                    finalCharacter += "your sharp wit and coins.";
                    break;
                case "ROGUE":
                    finalCharacter += "daggers and potions.";
                    break;
                default:
                    finalCharacter += "nothing and emptyness.";
                    break;
            }
            finalCharacter += "\n";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"So little {classes.ToUpper()} {race.ToUpper()} what faction do you support?");
            Console.Write("There are several filled with your bretheren. [");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(factions);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.White;
            factions = Console.ReadLine();
            switch (factions.ToUpper())
            {
                case "STORMFRONT":
                    finalCharacter += "The backwater and gloomy city you live in is rotting, you need to get out!";
                    break;
                case "DARKWORLD":
                    finalCharacter += "The other side of the portal is lacking in light but this is where you were born.";
                    break;
                case "YGGDRASIL":
                    finalCharacter += "The mother of all nature is your home Yggdrasil, the darkness draw nearer every day.";
                    break;
                case "FORESTCHILD":
                    finalCharacter += "Your people abandoned the mother tree, mostly consists of halfbreeds.";
                    break;
                case "ELDON":
                    finalCharacter += "Your home is one of the strongholds for humans, giant walls encompass the grand city.";
                    break;
                case "MERCCOR":
                    finalCharacter += "Your home is the Mercenary corps, you travel everywhere someone need a merch.";
                    break;
                case "BLACKROCK":
                    finalCharacter += "The deep mines is where you were born, the mines is where you sleep.";
                    break;
                case "LAVAFELL":
                    finalCharacter += "The extreme heat has hardened your shell of skin, your people governe the miners of Blackrock.";
                    break;
                case "BURROW":
                    finalCharacter += "Living in holes has its benefits, animals do it so why shouldnt you?";
                    break;
                case "HILLS":
                    finalCharacter += "Although your cousin lives in a burrow, a hollowed out hill is deffinitely more comfortable.";
                    break;
                default:
                    factions = "none";
                    finalCharacter += "You were born among it and the abyss gazes at you.";
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Little {race.ToUpper()} what is your name?: ");
            Console.ForegroundColor = ConsoleColor.White;
            characterName = Console.ReadLine();

            finalCharacter += $"\nThou name art {characterName}.";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(finalCharacter);
            Console.ReadKey();
        }
    }
}
