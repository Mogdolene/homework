using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    public delegate void ChangeSpeedEventHandler();
    public delegate void AccidentEventHandler();

    public class Game
    {
        private readonly List<BaseCar> _cars = new List<BaseCar>();
        private readonly Random _rand = new Random();
        private int _distance;

        public event ChangeSpeedEventHandler SpeedChanged;
        public event AccidentEventHandler AccidentHappened;

        public void StartGame()
        {
            _distance = _rand.Next(1, 10);
            GenerateCars();
            ShowCars();
            Console.WriteLine($"\nGame started.\nDistance: {_distance} km\n");

            //автомобілі розганяються))

            for (int i = 0; i < 5; i++)
            {
                foreach (var car in _cars)
                {
                    car.IncreaseSpeed();
                    car.PassedDist();
                }
                Thread.Sleep(2000);
            }
            bool flag = true;
            while (flag)
            {
                foreach (var car in _cars)
                {
                    Console.WriteLine($"Car № {car.Number}, currently speed: {car.Speed}");
                    car.PassedDist();
                }
                ChangeSpeed();
                Accident();
                foreach (var car in _cars)
                {
                    if (car.Distance >= _distance)
                    {
                        car.GameEnded();
                        flag = false;
                        break;
                    }
                }
                Thread.Sleep(2000);
                Console.WriteLine();
            }
            _cars.Clear();
        }

        public void ChangeSpeed()
        {
            if (_rand.Next(1, 10) == 5)                  //швидкість змінюється
            {
                OnSpeedChanged();
                var number = _rand.Next(0, _cars.Count);
                Console.WriteLine($"\nCar № {_cars[number].Number}, currently speed: {_cars[number].Speed}\nSpeed is changing...");
                Thread.Sleep(2000);
                if (_rand.Next(1, 2) == 1)              //збільшується
                {
                    _cars[number].IncreaseSpeed();
                }
                else                                    //змешнується
                {
                    _cars[number].DecreaseSpeed();
                }
            }
        }

        public void Accident()
        {
            if (_rand.Next(1, 1) == 1 && _cars.Count > 1) //сталася аварія
            {
                OnAccidentHappened();
                var number = _rand.Next(0, _cars.Count);
                Console.WriteLine($"\nCar № {_cars[number].Number} have an accident. The car has left the game.");
                _cars.Remove(_cars[number]);
            }
        }

        private void GenerateCars()
        {
            for (int i = 0; i < _rand.Next(3, 7); i++)
            {
                switch (_rand.Next(1, 4))
                {
                    case 1:
                    {
                        var car = new SportsCar(i + 1);
                        car.Finished += car.ThisCarFinished;
                        _cars.Add(car);
                        break;
                    }
                    case 2:
                    {
                        var car = new Car(i + 1);
                        car.Finished += car.ThisCarFinished;
                        _cars.Add(car);
                        break;
                    }
                    case 3:
                    {
                        var car = new Truck(i + 1);
                        car.Finished += car.ThisCarFinished;
                        _cars.Add(car);
                        break;
                    }
                    case 4:
                    {
                        var car = new Bus(i + 1);
                        car.Finished += car.ThisCarFinished;
                        _cars.Add(car);
                        break;
                    }
                }
            }
        }

        private void ShowCars()
        {
            Console.WriteLine("\nParticipants:");
            foreach (var car in _cars)
            {
                Console.WriteLine($"Car № {car.Number}\nType: {car.Type}\nMax speed: {car.MaxSpeed}\n");
            }
        }
        
        protected void OnSpeedChanged()
        {
            SpeedChanged?.Invoke();
        }

        protected void OnAccidentHappened()
        {
            AccidentHappened?.Invoke();
        }
    }
}
