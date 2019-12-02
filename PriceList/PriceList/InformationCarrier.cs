using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceList
{
    public abstract class InformationCarrier
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual string Print()
        {
            return $"\nName: {Name}\nManufacturer: {Manufacturer}\nModel: {Model}\nQuantity: {Quantity}\nPrice: {Price}";
        }

        public virtual string UploadData(string file)
        {
            return $"File {file} was uploaded to";
        }

        public virtual string DownloadData(string file)
        {
            return $"File {file} was downloaded to";
        }
    }
}
