using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DiscHelper();

            var carrier1= new FlashMemory()
            {
                Name = "Flash",
                Manufacturer = "Flash",
                MemoryCapacity = 111,
                Model = "flash1",
                Speed = 435,
                Price = 235.5,
                Quantity = 120
            };
            var carrier2 = new RemovableHDD()
            {
                Name = "HDD",
                Manufacturer = "HDD",
                Model = "hdd1",
                Speed = 100,
                Price = 335.5,
                Quantity = 100,
                Size = 250
            };
            var carrier3 = new DVDdisc()
            {
                Name = "DVD",
                Manufacturer = "DVD",
                Model = "dvd1",
                Price = 400.25,
                Quantity = 150,
                ReadSpeed = 120,
                WriteSpeed = 120
            };
            list.AddCarrier(carrier1);
            list.AddCarrier(carrier2);
            list.AddCarrier(carrier3);

            while (true)
            {
                Console.WriteLine("1. Add a new carrier\n2. Delete carrier\n3. Print list\n4. Change parameter\n5. Search a carrier");
                switch (Console.ReadLine())
                {
                    case "1":
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
                        }
                        else
                        {
                            Console.WriteLine("Wrong number!");
                        }

                        break;
                    }
                    case "2":
                    {
                        list.DeleteCarrier();
                        break;
                    }
                    case "3":
                    {
                        list.PrintList();
                        break;
                    }
                    case "4":
                    {
                        list.Change();
                        break;
                    }
                    case "5":
                    {
                        list.SearchCarrier();
                        break;
                    }
                }

                Console.WriteLine("Do you want to fo anything else?\n1. Yes\n2. No");
                if (Console.ReadLine() == "1")
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
