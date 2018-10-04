using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;

namespace learn_english
{
    class Program
    {
        enum Secenekler
        {
            LETTERS = 1,
            KEYWORDS = 2
        }
        static void Main(string[] args)
        {
            int mode;
            Console.Title = "learn-english";
            Console.WriteLine("**************************");
            Console.WriteLine("1 - HARFLERİN OKUNUŞU");
            Console.WriteLine("2 - KELİMELERİN ANLAMLARI");
            Console.WriteLine("**************************");
            int stdinMode = int.Parse(Console.ReadLine());
            if (stdinMode == (int)Secenekler.LETTERS)
            {
                mode = 1;
            }
            else
            {
                mode = 2;
            }
            Console.Clear();

            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=db.sqlite3;Version=3;Compress=True;");
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_cmd = sqlite_conn.CreateCommand();

            if (mode == 1)
            {
                sqlite_cmd.CommandText = "SELECT * FROM letters ORDER BY RANDOM() LIMIT 1";
                Console.WriteLine("Harflerin Türkçe okunuşunu yazınız.");
            }
            else
            {
                sqlite_cmd.CommandText = "SELECT * FROM keywords ORDER BY RANDOM() LIMIT 1";
                Console.WriteLine("Harflerin Türkçe kelime anlamlarını yazınız.");
            }
            Console.ReadKey();
            Console.Clear();

            while (true)
            {
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();
                String question = (String)sqlite_datareader["question"];
                String answer = (String)sqlite_datareader["answer"];

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
