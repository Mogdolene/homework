using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate void EndEventHandler();

    public interface ICarFinished
    {
        event EndEventHandler Finished;
    }
}
