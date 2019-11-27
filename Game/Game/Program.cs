using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you want to start a game?\n1. Yes\n2. No");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    {
                        game.SpeedChanged += SpeedChange;
                        game.AccidentHappened += Accident;
                        game.StartGame();
                        game.AccidentHappened -= Accident;
                        game.SpeedChanged -= SpeedChange;
                        Console.ReadKey();
                        break;
                    }
                    case ConsoleKey.D2:
                        Environment.Exit(0);
                        break;
                }
            }

            Console.ReadLine();
        }

        public static void Accident()
        {
            Console.WriteLine("\nSome car has got into an accident.");
        }

        public static void SpeedChange()
        {
            Console.WriteLine("\nThe speed of some car has changed.");
        }
    }
}
