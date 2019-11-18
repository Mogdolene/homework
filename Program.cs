using System;
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
                Console.WriteLine("1. Delete carrier\n2. Print list\n3. Change parameter\n4. Search a carrier");
                switch (Console.ReadLine())
                {
                    case "1":
                    {
                        list.DeleteCarrier();
                        break;
                    }
                    case "2":
                    {
                        list.PrintList();
                        break;
                    }
                    case "3":
                    {
                        list.Change();
                        break;
                    }
                    case "4":
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
