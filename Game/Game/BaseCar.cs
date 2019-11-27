using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class BaseCar: ICarFinished
    {
        public event EndEventHandler Finished;

        public int MaxSpeed;
        public int Number;
        public string Type;
        public int Speed;
        public double Distance;

        public BaseCar()
        {
            MaxSpeed = 0;
            Number = 0;
            Type = "";
            Speed = 0;
            Distance = 0;
        }

        public virtual void IncreaseSpeed() { }
        public virtual void DecreaseSpeed() { }

        public void PassedDist()
        {
            Distance += Speed * 0.000833;
            Console.WriteLine($"Passed distance: {Distance} km\n");
        }

        public void GameEnded()
        {
            OnFinished();
        }

        void OnFinished()
        {
            Finished?.Invoke();
        }

        public void ThisCarFinished()
        {
            Console.WriteLine($"Winner is car № {Number}!\nGame ended.");
        }
    }
}
