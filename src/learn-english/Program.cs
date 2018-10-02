using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learn_english
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> letters = new Dictionary<string, string> {
                { "a", "ey" },
                { "b", "bi" },
                { "c", "si" },
                { "d", "di" },
                { "e", "i" },
                { "f", "ef" },
                { "g", "ci" },
                { "h", "eyç" },
                { "i", "ay" },
                { "j", "cey" },
                { "k", "key" },
                { "l", "el" },
                { "m", "em" },
                { "n", "en" },
                { "o", "ouğ" },
                { "p", "pi" },
                { "q", "küuğ" },
                { "r", "ağr" },
                { "s", "es" },
                { "t", "ti" },
                { "u", "yuğ" },
                { "v", "vi" },
                { "w", "dabılyuğ" },
                { "x", "ekz" },
                { "y", "vay" },
                { "z", "zed" },
            };
            Console.Title = "learn-english";
            Console.WriteLine("Harflerin Türkçe okunuşunu yazınız.");
            Console.ReadKey();
            Console.Clear();

            while (true)
            {
                Random rand = new Random();
                var randomEntry = letters.ElementAt(rand.Next(0, letters.Count));
                String question = randomEntry.Key;
                String answer = randomEntry.Value;

                Console.WriteLine(question);
                String stdin = Console.ReadLine();
                if (stdin != answer)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Yanlış... Cevap: " + answer);
                    Console.ResetColor();
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
    }
}
