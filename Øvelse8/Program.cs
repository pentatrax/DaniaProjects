using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> questions = new Dictionary<string, string>();
            questions.Add("Is the color black, darker than vantablack?", "no");
            questions.Add("What is the capital of Denmark?", "copenhagen");
            questions.Add("Is Denmark a capitalist country?", "yes");
            questions.Add("Does a snail have eyes or antennas?", "eyes");
            questions.Add("From what country did H. C. Andersen come from?", "denmark");
            questions.Add("Is this true?", "yes");
            questions.Add("A cappybare walk insto a bar and says?", "ouch");
            questions.Add("Santa wears red and spreads gift for free, santa is...", "communist");
            questions.Add("Snow is deffinitely not water?", "false");
            byte points = Convert.ToByte(questions.ToArray().Length);

            Array answers = questions.ToArray();
            Console.WriteLine(answers.GetValue(0));
            Console.ReadKey();
        }
    }
}
