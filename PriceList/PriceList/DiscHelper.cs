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
        private List<InformationCarrier> _carriers;

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
            Console.WriteLine("\nSelect a criterion:\n1. Name\n2. Manufacturer\n3. Model\n4. Quantity\n5. Price");
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
                case "4":
                {
                    Console.WriteLine("Enter a criterion:");
                    var criterion = Console.ReadLine();
                    if (int.TryParse(criterion, out int result))
                    {
                        for (int i = 0; i < _carriers.Count; i++)
                        {

                            if (_carriers[i].Quantity == result)
                            {
                                _carriers.Remove(_carriers[i]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error! You haven't written a right number.");
                    }
                    break;
                }
                case "5":
                {
                    Console.WriteLine("Enter a criterion:");
                    var criterion = Console.ReadLine();
                    if (double.TryParse(criterion, out double result))
                    {
                        for (int i = 0; i < _carriers.Count; i++)
                        {

                            if (_carriers[i].Price == result)
                            {
                                _carriers.Remove(_carriers[i]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error! You haven't written a right number.");
                    }
                    break;
                }
                default:
                {
                    Console.WriteLine("Wrong number!");
                    break;
                }
            }
            Console.WriteLine("\nCarrier was deleted.");
        }

        public void SearchCarrier()
        {
            Console.WriteLine("\nSelect a criterion:\n1. Name\n2. Manufacturer\n3. Model\n4. Quantity\n5. Price");
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
                        if (_carriers[i].Manufacturer == criterion)
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
                        if (_carriers[i].Model == criterion)
                        {
                            Console.WriteLine(_carriers[i].Print());
                        }
                    }
                    break;
                }
                case "4":
                {
                    Console.WriteLine("Enter a criterion:");
                    var criterion = Console.ReadLine();
                    if (int.TryParse(criterion, out int result))
                    {
                        for (int i = 0; i < _carriers.Count; i++)
                        {

                            if (_carriers[i].Quantity == result)
                            {
                                Console.WriteLine(_carriers[i].Print());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error! You haven't written a right number.");
                    }
                    break;
                }
                case "5":
                {
                    Console.WriteLine("Enter a criterion:");
                    var criterion = Console.ReadLine();
                    if (double.TryParse(criterion, out double result))
                    {
                        for (int i = 0; i < _carriers.Count; i++)
                        {

                            if (_carriers[i].Price == result)
                            {
                                Console.WriteLine(_carriers[i].Print());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error! You haven't written a right number.");
                    }
                    break;
                }
                default:
                {
                    Console.WriteLine("Wrong number!");
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
                Console.WriteLine($"{i+1}. {_carriers[i].Print()}");
            }
        }
    }
}
