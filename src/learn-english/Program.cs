using System;
using System.Text;
using System.Linq;

namespace learn_english
{
    class Program
    {
        enum Options
        {
            LETTERS = 1,
            NUMBERS = 2,
            KEYWORDS = 3,
            TIME = 4
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;


            int mode;
            Console.Title = "learn-english";
            Console.WriteLine("**************************");
            Console.WriteLine("1 - HARFLERİN OKUNUŞU");
            Console.WriteLine("2 - SAYILAR");
            Console.WriteLine("3 - KELİMELERİN ANLAMLARI");
            Console.WriteLine("4 - VAKİT");
            Console.WriteLine("**************************");
            int stdinMode = int.Parse(Console.ReadLine());
            switch (stdinMode)
            {
                case (int)Options.LETTERS:
                    mode = 1;
                    break;
                case (int)Options.NUMBERS:
                    mode = 2;
                    break;
                case (int)Options.KEYWORDS:
                    mode = 3;
                    break;
                case (int)Options.TIME:
                    mode = 4;
                    break;
                default:
                    mode = 1;
                    break;
            }
            Console.Clear();

            using (var db = new dbEntities())
            {
                if (mode == (int)Options.LETTERS)
                {
                    Console.WriteLine("Harflerin Türkçe okunuşunu yazınız.");
                }
                else if (mode == (int)Options.NUMBERS)
                {
                    Console.WriteLine("Sayıların İngilizce okunuşunu yazınız.");
                }
                else if (mode == (int)Options.KEYWORDS)
                {
                    Console.WriteLine("Harflerin Türkçe kelime anlamlarını yazınız.");
                }
                else if (mode == (int)Options.TIME)
                {
                    Console.WriteLine("Kelimelerin Türkçe kelime anlamlarını yazınız.");
                }
                Console.ReadKey();
                Console.Clear();

                while (true)
                {
                    String question = "";
                    String answer = "";

                    if (mode == (int)Options.LETTERS)
                    {
                        IQueryable<letters> rows = db.letters.OrderBy(x => Guid.NewGuid()).Take(1);
                        question = rows.First().question;
                        answer = rows.First().answer;
                    }
                    else if (mode == (int)Options.NUMBERS)
                    {
                        IQueryable<numbers> rows = db.numbers.OrderBy(x => Guid.NewGuid()).Take(1);
                        question = rows.First().question;
                        answer = rows.First().answer;
                    }
                    else if (mode == (int)Options.KEYWORDS)
                    {
                        IQueryable<keywords> rows = db.keywords.OrderBy(x => Guid.NewGuid()).Take(1);
                        question = rows.First().question;
                        answer = rows.First().answer;
                    }
                    else if (mode == (int)Options.TIME)
                    {
                        IQueryable<time> rows = db.time.OrderBy(x => Guid.NewGuid()).Take(1);
                        question = rows.First().question;
                        answer = rows.First().answer;
                    }

                    Console.WriteLine(question);
                    String stdin = Console.ReadLine().ToLower();
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
}
