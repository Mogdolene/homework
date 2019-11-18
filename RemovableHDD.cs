using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    public class RemovableHDD: InformationCarrier
    {
        public int Size { get; set; }
        public int Speed { get; set; }
        private RemovableHDD _carrier;

        public override string Print()
        {
            return $"{base.Print()}\nDisc size: {Size}\nUSB speed: {Speed}\n";
        }

        public override string UploadData(string file)
        {
            return $"{base.UploadData(file)} removable HDD.";
        }

        public override string DownloadData(string file)
        {
            return $"{base.DownloadData(file)} removable HDD.";
        }
    }
}
