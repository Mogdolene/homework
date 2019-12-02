using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PriceList
{
    public class XmlHelper
    {
        private readonly string _fileName;

        public XmlHelper(string fileName)
        {
            _fileName = fileName;
        }

        public void CreateFile()
        {
            if (!File.Exists(_fileName))
            {
                var writer = new XmlTextWriter(_fileName, Encoding.UTF8);
                writer.WriteStartDocument();
                writer.WriteStartElement("carriers");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        public void SaveFlash(FlashMemory carrier)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(_fileName);

                var root = doc.CreateElement("flash_drive");
                doc.DocumentElement?.AppendChild(root);

                var name = doc.CreateAttribute("name");
                name.Value = carrier.Name;
                root.Attributes.Append(name);

                var manufacturer = doc.CreateElement("manufacturer");
                manufacturer.InnerText = carrier.Manufacturer;
                root.AppendChild(manufacturer);

                var model = doc.CreateElement("model");
                model.InnerText = carrier.Model;
                root.AppendChild(model);

                var quantity = doc.CreateElement("quantity");
                quantity.InnerText = $"{carrier.Quantity}";
                root.AppendChild(quantity);

                var price = doc.CreateElement("price");
                price.InnerText = $"{carrier.Price}";
                root.AppendChild(price);

                var memoryCap = doc.CreateElement("memory_capacity");
                memoryCap.InnerText = $"{carrier.MemoryCapacity}";
                root.AppendChild(memoryCap);

                var speed = doc.CreateElement("USB_speed");
                speed.InnerText = $"{carrier.Speed}";
                root.AppendChild(speed);

                doc.Save(_fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SaveHDD(RemovableHDD carrier)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(_fileName);

                var root = doc.CreateElement("hdd");
                doc.DocumentElement?.AppendChild(root);

                var name = doc.CreateAttribute("name");
                name.Value = carrier.Name;
                root.Attributes.Append(name);

                var manufacturer = doc.CreateElement("manufacturer");
                manufacturer.InnerText = carrier.Manufacturer;
                root.AppendChild(manufacturer);

                var model = doc.CreateElement("model");
                model.InnerText = carrier.Model;
                root.AppendChild(model);

                var quantity = doc.CreateElement("quantity");
                quantity.InnerText = $"{carrier.Quantity}";
                root.AppendChild(quantity);

                var price = doc.CreateElement("price");
                price.InnerText = $"{carrier.Price}";
                root.AppendChild(price);

                var size = doc.CreateElement("disc_size");
                size.InnerText = $"{carrier.Size}";
                root.AppendChild(size);

                var speed = doc.CreateElement("USB_speed");
                speed.InnerText = $"{carrier.Speed}";
                root.AppendChild(speed);

                doc.Save(_fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SaveDVD(DVDdisc carrier)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(_fileName);

                var root = doc.CreateElement("dvd");
                doc.DocumentElement?.AppendChild(root);

                var name = doc.CreateAttribute("name");
                name.Value = carrier.Name;
                root.Attributes.Append(name);

                var manufacturer = doc.CreateElement("manufacturer");
                manufacturer.InnerText = carrier.Manufacturer;
                root.AppendChild(manufacturer);

                var model = doc.CreateElement("model");
                model.InnerText = carrier.Model;
                root.AppendChild(model);

                var quantity = doc.CreateElement("quantity");
                quantity.InnerText = $"{carrier.Quantity}";
                root.AppendChild(quantity);

                var price = doc.CreateElement("price");
                price.InnerText = $"{carrier.Price}";
                root.AppendChild(price);

                var readSpeed = doc.CreateElement("reading_speed");
                readSpeed.InnerText = $"{carrier.ReadSpeed}";
                root.AppendChild(readSpeed);

                var writeSpeed = doc.CreateElement("writing_speed");
                writeSpeed.InnerText = $"{carrier.WriteSpeed}";
                root.AppendChild(writeSpeed);

                doc.Save(_fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(string value, string criterion)
        {
            var doc = new XmlDocument();
            doc.Load(_fileName);

            XmlNodeList carrierNodes;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0) carrierNodes = doc.GetElementsByTagName("flash_drive");
                else if (i == 1) carrierNodes = doc.GetElementsByTagName("hdd");
                else carrierNodes = doc.GetElementsByTagName("dvd");

                foreach (XmlElement carrierRoot in carrierNodes)
                {
                    var cr = carrierRoot.Attributes[$"{criterion}"].Value;
                    if (string.IsNullOrWhiteSpace(cr)) continue;
                    if (!value.Equals(cr)) continue;

                    var parent = carrierRoot.ParentNode;
                    parent?.RemoveChild(carrierRoot);

                    break;
                }
            }
            doc.Save(_fileName);
        }

#if true
        public List<InformationCarrier> LoadCarriers()
        {
            try
            {
                var items = new List<InformationCarrier>();

                var doc = new XmlDocument();
                doc.Load(_fileName);

                for (int i = 0; i < 3; i++)
                {
                    XmlNodeList carrierNodes;
                    if (i == 0) carrierNodes = doc.GetElementsByTagName("flash_drive");
                    else if (i == 1) carrierNodes = doc.GetElementsByTagName("hdd");
                    else carrierNodes = doc.GetElementsByTagName("dvd");

                    if (carrierNodes.Count == 0) return items;
                    
                    foreach (XmlElement carrierRoot in carrierNodes)
                    {
                        if (i == 0)
                        {
                            var carrier = new FlashMemory();
                            var nameAttr = carrierRoot.Attributes["name"].Value;
                            if (!string.IsNullOrWhiteSpace(nameAttr))
                            {
                                carrier.Name = nameAttr;
                            }

                            foreach (XmlElement carrierProps in carrierRoot)
                            {
                                switch (carrierProps.Name)
                                {
                                    case "manufacturer":
                                        carrier.Manufacturer = carrierProps.InnerText;
                                        break;
                                    case "model":
                                        carrier.Model = carrierProps.InnerText;
                                        break;
                                    case "quantity":
                                        if (int.TryParse(carrierProps.InnerText, out var quantity))
                                        {
                                            carrier.Quantity = quantity;
                                        }
                                        break;
                                    case "price":
                                        if (double.TryParse(carrierProps.InnerText, out var price))
                                        {
                                            carrier.Price = price;
                                        }
                                        break;
                                    case "memory_capacity":
                                        if (int.TryParse(carrierProps.InnerText, out var memCap))
                                        {
                                            carrier.MemoryCapacity = memCap;
                                        }
                                        break;
                                    case "USB_speed":
                                        if (int.TryParse(carrierProps.InnerText, out var speed))
                                        {
                                            carrier.Speed = speed;
                                        }
                                        break;
                                }
                            }
                            items.Add(carrier);
                        }
                        else if (i == 1)
                        {
                            var carrier = new RemovableHDD();
                            var nameAttr = carrierRoot.Attributes["name"].Value;
                            if (!string.IsNullOrWhiteSpace(nameAttr))
                            {
                                carrier.Name = nameAttr;
                            }

                            foreach (XmlElement carrierProps in carrierRoot)
                            {
                                switch (carrierProps.Name)
                                {
                                    case "manufacturer":
                                        carrier.Manufacturer = carrierProps.InnerText;
                                        break;
                                    case "model":
                                        carrier.Model = carrierProps.InnerText;
                                        break;
                                    case "quantity":
                                        if (int.TryParse(carrierProps.InnerText, out var quantity))
                                        {
                                            carrier.Quantity = quantity;
                                        }
                                        break;
                                    case "price":
                                        if (double.TryParse(carrierProps.InnerText, out var price))
                                        {
                                            carrier.Price = price;
                                        }
                                        break;
                                    case "disc_size":
                                        if (int.TryParse(carrierProps.InnerText, out var discSize))
                                        {
                                            carrier.Size = discSize;
                                        }
                                        break;
                                    case "USB_speed":
                                        if (int.TryParse(carrierProps.InnerText, out var speed))
                                        {
                                            carrier.Speed = speed;
                                        }
                                        break;
                                }
                            }
                            items.Add(carrier);
                        }
                        else
                        {
                            var carrier = new DVDdisc();
                            var nameAttr = carrierRoot.Attributes["name"].Value;
                            if (!string.IsNullOrWhiteSpace(nameAttr))
                            {
                                carrier.Name = nameAttr;
                            }

                            foreach (XmlElement carrierProps in carrierRoot)
                            {
                                switch (carrierProps.Name)
                                {
                                    case "manufacturer":
                                        carrier.Manufacturer = carrierProps.InnerText;
                                        break;
                                    case "model":
                                        carrier.Model = carrierProps.InnerText;
                                        break;
                                    case "quantity":
                                        if (int.TryParse(carrierProps.InnerText, out var quantity))
                                        {
                                            carrier.Quantity = quantity;
                                        }
                                        break;
                                    case "price":
                                        if (double.TryParse(carrierProps.InnerText, out var price))
                                        {
                                            carrier.Price = price;
                                        }
                                        break;
                                    case "reading_speed":
                                        if (int.TryParse(carrierProps.InnerText, out var read))
                                        {
                                            carrier.ReadSpeed = read;
                                        }
                                        break;
                                    case "writing_speed":
                                        if (int.TryParse(carrierProps.InnerText, out var write))
                                        {
                                            carrier.WriteSpeed = write;
                                        }
                                        break;
                                }
                            }
                            items.Add(carrier);
                        }
                    }
                }

                return items;
            }
            //catch (Exception)
            //{
            //    //throw;
            //}
            finally{}
        }
#endif
    }
}
