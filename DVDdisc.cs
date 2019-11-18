using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    public class DVDdisc: InformationCarrier
    {
        public int ReadSpeed { get; set; }
        public int WriteSpeed { get; set; }
        private DVDdisc _carrier;

        public override string Print()
        {
            return $"{base.Print()}\nReading speed: {ReadSpeed}\nWriting speed: {WriteSpeed}\n";
        }

        public override string UploadData(string file)
        {
            return $"{base.UploadData(file)} DVD disc.";
        }

        public override string DownloadData(string file)
        {
            return $"{base.DownloadData(file)} DVD disc.";
        }
    }
}
