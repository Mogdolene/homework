using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bus: BaseCar
    {
        public Bus(int number) : base()
        {
            MaxSpeed = 140;
            Number = number;
            Type = "bus";
        }

        public override void IncreaseSpeed()
        {
            if (Speed + 10 <= MaxSpeed) Speed += 10;
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
