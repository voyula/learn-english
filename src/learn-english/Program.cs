using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;

namespace learn_english
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=db.sqlite3;Version=3;Compress=True;");
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            Console.Title = "learn-english";
            Console.WriteLine("Harflerin Türkçe okunuşunu yazınız.");
            Console.ReadKey();
            Console.Clear();

            sqlite_cmd = sqlite_conn.CreateCommand(); 
            sqlite_cmd.CommandText = "SELECT * FROM letters ORDER BY RANDOM() LIMIT 1";
            while (true)
            {
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();
                String question = (String) sqlite_datareader["question"];
                String answer = (String) sqlite_datareader["answer"];

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
