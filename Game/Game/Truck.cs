using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Truck: BaseCar
    {
        public Truck(int number) : base()
        {
            MaxSpeed = 160;
            Number = number;
            Type = "truck";
        }

        public override void IncreaseSpeed()
        {
            if (Speed + 15 <= MaxSpeed) Speed += 15;
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
