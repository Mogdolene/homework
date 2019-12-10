using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Student: Human
    {
        public string Faculty { get; }
        public string Group { get; set; }
    }
}