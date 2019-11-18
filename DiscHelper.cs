using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    public class DiscHelper
    {
        public List<InformationCarrier> _carriers;

        public DiscHelper()
        {
            _carriers = new List<InformationCarrier>();
        }

        public void AddCarrier(InformationCarrier carrier)
        {
            _carriers.Add(carrier);
            Console.WriteLine("Carrier was added.");
        }
        
        public void DeleteCarrier()
        {
            Console.WriteLine("\nSelect a criterion:\n1. Name\n2. Manufacturer\n3. Model");
            switch (Console.ReadLine())
            {
                case "1":
                {
                    Console.Write("Enter a criterion:");
                    string criterion = Console.ReadLine();
                    for (int i=0; i<_carriers.Count; i++)
                    {
                        if (_carriers[i].Name == criterion)
                        {
                            _carriers.Remove(_carriers[i]);
                        }
                    }
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Enter a criterion:");
                    var criterion = Console.ReadLine();
                    for (int i = 0; i < _carriers.Count; i++)
                    {
                        if (_carriers[i].Manufacturer == criterion)
                        {
                            _carriers.Remove(_carriers[i]);
                        }
                    }
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Enter a criterion:");
                    var criterion = Console.ReadLine();
                    for (int i = 0; i < _carriers.Count; i++)
                    {
                        if (_carriers[i].Model == criterion)
                        {
                            _carriers.Remove(_carriers[i]);
                        }
                    }
                    break;
                }
            }

            Console.WriteLine("\nCarrier was deleted.");
        }

        public void SearchCarrier()
        {
            Console.WriteLine("\nSelect a criterion:\n1. Name\n2.Manufacturer\n3. Model");
            switch (Console.ReadLine())
            {
                case "1":
                {
                    Console.WriteLine("Enter a criterion:");
                    var criterion = Console.ReadLine();
                    for (int i = 0; i < _carriers.Count; i++)
                    {
                        if (_carriers[i].Name == criterion)
                        {
                            Console.WriteLine(_carriers[i].Print());
                        }
                    }
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Enter a criterion:");
                    var criterion = Console.ReadLine();
                    for (int i = 0; i < _carriers.Count; i++)
                    {
                        if (_carriers[i].Name == criterion)
                        {
                            Console.WriteLine(_carriers[i].Print());
                        }
                    }
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Enter a criterion:");
                    var criterion = Console.ReadLine();
                    for (int i = 0; i < _carriers.Count; i++)
                    {
                        if (_carriers[i].Name == criterion)
                        {
                            Console.WriteLine(_carriers[i].Print());
                        }
                    }
                    break;
                }
            }
        }

        public void Change()
        {
            Console.Write("\nEnter number of carrier, which you want to change: ");
            int i = int.Parse(Console.ReadLine());
            Console.Write("\nEnter parameter, which you want to change:\n1. Quantity\n2. Price\n");
            string j = Console.ReadLine();
            Console.Write("\nEnter new value: ");
            if (j == "1")
            {
                _carriers[i].Quantity = int.Parse(Console.ReadLine());
            }
            else
            {
                _carriers[i].Price = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nParameter was changed.");
        }

        public void PrintList()
        {
            for (int i=0; i<_carriers.Count; i++)
            {
                Console.WriteLine($"{i}. {_carriers[i].Print()}");
            }
        }
    }
}
