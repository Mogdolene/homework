using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    public class FlashMemory: InformationCarrier
    {
        public int MemoryCapacity { get; set; }
        public int Speed { get; set; }

        public override string Print()
        {
            return $"{base.Print()}\nMemory capacity: {MemoryCapacity}\nSpeed: {Speed}\n";
        }

        public override string UploadData(string file)
        {
            return $"{base.UploadData(file)} Flash memory.";
        }

        public override string DownloadData(string file)
        {
            return $"{base.DownloadData(file)} Flash memory.";
        }
    }
}
