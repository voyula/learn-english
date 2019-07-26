using System;
using System.Text;
using System.Data.SQLite;

namespace learn_english
{
    class Program
    {
        enum Options
        {
            LETTERS = 1,
            NUMBERS = 2,
            KEYWORDS = 3
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
                default:
                    mode = 1;
                    break;
            }
            Console.Clear();

            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=db.sqlite3;Version=3;Compress=True;");
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd;

            sqlite_cmd = sqlite_conn.CreateCommand();

            if (mode == 1)
            {
                sqlite_cmd.CommandText = "SELECT * FROM letters ORDER BY RANDOM() LIMIT 1";
                Console.WriteLine("Harflerin Türkçe okunuşunu yazınız.");
            }
            else if (mode == 2)
            {
                sqlite_cmd.CommandText = "SELECT * FROM numbers ORDER BY RANDOM() LIMIT 1";
                Console.WriteLine("Sayıların ingilizce okunuşunu yazınız.");
            }
            else if (mode == 3)
            {
                sqlite_cmd.CommandText = "SELECT * FROM keywords ORDER BY RANDOM() LIMIT 1";
                Console.WriteLine("Harflerin Türkçe kelime anlamlarını yazınız.");
            }
            Console.ReadKey();
            Console.Clear();

            using (SQLiteDataReader reader = sqlite_cmd.ExecuteReader())
            {
                while (true)
                {
                    reader.Read();
                    String question = (String)reader["question"];
                    String answer = (String)reader["answer"];

                scope:
                    Console.WriteLine(question);
                    String stdin = Console.ReadLine().ToLower();
                    if (stdin != answer)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Yanlış... Cevap: " + answer);
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        goto scope;
                    }
                    Console.Clear();
                }
            }
        }
    }
}
