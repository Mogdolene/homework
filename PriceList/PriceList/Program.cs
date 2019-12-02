using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    class Program
    {
        public static XmlHelper xml = new XmlHelper("carriers.xml");
        static void Main(string[] args)
        {
            var list = new DiscHelper();
            xml.CreateFile();

            var carriers = xml.LoadCarriers();
            foreach (var informationCarrier in carriers)
            {
                list.AddCarrier(informationCarrier);
            }

            while (true)
            {
                Console.WriteLine("1. Add a new carrier\n2. Delete carrier\n3. Print list\n4. Change parameter\n5. Search a carrier");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    {
                        Console.WriteLine("What so you want to add: (1) flash drive, (2) removable HDD or (3) DVD disc?");
                        string[] buf=new string[7];
                        string choice = Console.ReadLine();
                        Console.Write("Enter name: ");
                        buf[0] = Console.ReadLine();
                        Console.Write("Enter manufacturer: ");
                        buf[1] = Console.ReadLine();
                        Console.Write("Enter model: ");
                        buf[2] = Console.ReadLine();
                        Console.Write("Enter quantity: ");
                        buf[3] = Console.ReadLine();
                        Console.Write("Enter price: ");
                        buf[4] = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.Write("Enter memory capacity: ");
                            buf[5] = Console.ReadLine();
                            Console.Write("Enter USB speed: ");
                            buf[6] = Console.ReadLine();
                            var carr = new FlashMemory()
                            {
                                Name = buf[0],
                                Manufacturer = buf[1],
                                Model = buf[2],
                                Quantity = int.Parse(buf[3]),
                                Price = double.Parse(buf[4]),
                                MemoryCapacity = int.Parse(buf[5]),
                                Speed = int.Parse(buf[6])
                            };
                            list.AddCarrier(carr);
                            xml.SaveFlash(carr);
                        }
                        else if (choice == "2")
                        {
                            Console.Write("Enter disc size: ");
                            buf[5] = Console.ReadLine();
                            Console.Write("Enter USB speed: ");
                            buf[6] = Console.ReadLine();
                            var carr = new RemovableHDD()
                            {
                                Name = buf[0],
                                Manufacturer = buf[1],
                                Model = buf[2],
                                Quantity = int.Parse(buf[3]),
                                Price = double.Parse(buf[4]),
                                Size = int.Parse(buf[5]),
                                Speed = int.Parse(buf[6])
                            };
                            list.AddCarrier(carr);
                            xml.SaveHDD(carr);
                        }
                        else if (choice == "3")
                        {
                            Console.Write("Enter reading speed: ");
                            buf[5] = Console.ReadLine();
                            Console.Write("Enter writing speed: ");
                            buf[6] = Console.ReadLine();
                            var carr = new DVDdisc()
                            {
                                Name = buf[0],
                                Manufacturer = buf[1],
                                Model = buf[2],
                                Quantity = int.Parse(buf[3]),
                                Price = double.Parse(buf[4]),
                                ReadSpeed = int.Parse(buf[5]),
                                WriteSpeed = int.Parse(buf[6])
                            };
                            list.AddCarrier(carr);
                            xml.SaveDVD(carr);
                        }
                        else
                        {
                            Console.WriteLine("Wrong number!");
                            return;
                        }

                        Console.WriteLine("Carrier was added.");
                        break;
                    }
                    case ConsoleKey.D2:
                    {
                        list.DeleteCarrier();
                        break;
                    }
                    case ConsoleKey.D3:
                    {
                        list.PrintList();
                        break;
                    }
                    case ConsoleKey.D4:
                    {
                        list.Change();
                        File.Delete("carriers.xml");
                        xml.CreateFile();
                        list.SaveToFile();
                        break;
                    }
                    case ConsoleKey.D5:
                    {
                        list.SearchCarrier();
                        break;
                    }
                }

                //xml.Clear();
                Console.WriteLine("Do you want to fo anything else?\n1. Yes\n2. No");
                if (Console.ReadKey().Key == ConsoleKey.D1) Console.Clear();
                else return;
            }
        }
    }
}
