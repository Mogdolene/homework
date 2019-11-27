using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Car: BaseCar
    {
        public Car(int number) : base()
        {
            MaxSpeed = 250;
            Number = number;
            Type = "car";
        }

        public override void IncreaseSpeed()
        {
            if (Speed + 25 <= MaxSpeed) Speed += 25;
            else Speed += MaxSpeed - Speed;
            Console.WriteLine($"Car № {Number}, currently speed: {Speed}");
        }

        public override void DecreaseSpeed()
        {
            if (Speed - 12 > 12) Speed -= 12;
            else Speed = 0;
            Console.WriteLine($"Car № {Number}, currently speed: {Speed}");
        }
    }
}
