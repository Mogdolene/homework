using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static string fileName = "SearchResults.txt";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                string directory = "D:\\Smth\\Фото і відео";
                string mask = "";

                Console.Write("Enter a mask (replace unknown symbols with '*', example: '*.png*'): ");
                mask = Console.ReadLine();

                Console.WriteLine();

                WriteToFile(fileName, $"{DateTime.Now}, search results:");

                SearchFiles(directory, mask);

                WriteToFile(fileName, "");

                Console.WriteLine("-------------\nIf this is not what you've searched, try again.\n\nWant to try again?\n1. Yes\n2. No");
                if (Console.ReadKey().Key != ConsoleKey.D1) return;
            }
        }

        private static void SearchFiles(string currentlyDir, string mask)
        {
            string[] dirFolders = Directory.GetDirectories(currentlyDir);
            string name, lastMod;

            foreach (var dirFolder in dirFolders)
            {
                var dirInfo = new DirectoryInfo(dirFolder);
                var dirFiles = dirInfo.GetFiles(mask);

                SearchFiles(dirFolder, mask);

                foreach (var dirFile in dirFiles)
                {
                    name = $"Directory name: {dirFile.Name}";
                    lastMod = $"Date of last modification: {dirFile.LastWriteTime}";
                    
                    Console.WriteLine($"{name}\n{lastMod}\n");
                    
                    WriteToFile(fileName, name);
                    WriteToFile(fileName, lastMod);
                }
            }
        }

        private static void WriteToFile(string fileName, string text)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fileStream))
                {
                    sw.WriteLine(text);
                }
            }
        }
    }
}
