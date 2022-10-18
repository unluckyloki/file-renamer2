using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "File renamer";

            while (true)
            {
                Console.Clear();
                string[] logo = {
                "╔╗       ╔╗    ",
                "║║       ║║    ",
                "║║   ╔══╗║║╔╗╔╗",
                "║║ ╔╗║╔╗║║╚╝╝╠╣",
                "║╚═╝║║╚╝║║╔╗╗║║",
                "╚═══╝╚══╝╚╝╚╝╚╝"
            };
                for (int i = 0; i < logo.Length; i++)
                {
                    Console.WriteLine(logo[i]);
                }

                try
                {
                    Console.Write("\nEnter directory path: ");
                    string dirPath = Console.ReadLine();
                    Console.Write("Enter start num: ");
                    int startNum = Convert.ToInt32(Console.ReadLine());

                    string[] filesList = Directory.GetFiles(dirPath);

                    for (int i = 0; i < filesList.Length; i++)
                    {
                        int sInd = filesList[i].LastIndexOf('\\');
                        int dInd = filesList[i].LastIndexOf('.');
                        string fileFormat = filesList[i].Substring(dInd);
                        int fileNum = i + startNum;
                        File.Move(filesList[i], filesList[i].Remove(sInd + 1) + fileNum + fileFormat);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nSuccessful operation\n");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSomething went wrong :D\n");
                    Console.WriteLine(e + "\n");
                    Console.ResetColor();
                }

                Console.WriteLine("[1] Rename another files");
                var key = Console.ReadKey(true).Key;
                do{
                    if (key == ConsoleKey.D1) break;
                    key = Console.ReadKey(true).Key;
                } while(key != ConsoleKey.D1 || key != ConsoleKey.D2);
            }
        }
    }
}