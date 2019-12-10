using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("What class do you want to save?\n1. Human\n2. Student\n3. Employee");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        FileHelper<Human>.CreateNewFile();
                        break;
                    case ConsoleKey.D2:
                        FileHelper<Student>.CreateNewFile();
                        break;
                    case ConsoleKey.D3:
                        FileHelper<Employee>.CreateNewFile();
                        break;
                }

                Console.WriteLine("\nDo you want to continue?\n1. Yes\n2. No");

                if (Console.ReadKey().Key == ConsoleKey.D1) continue;
                else return;

            } while (true);
        }
    }
}