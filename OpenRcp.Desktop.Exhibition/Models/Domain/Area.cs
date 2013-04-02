using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OpenRcp.Desktop.Exhibition.Domain
{
    public class Area : IItemFinder<Device, string>
    {
        private string name;

        [XmlAttribute("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Device[] deviceItems;

        [XmlElement("device")]
        public Device[] DeviceItems
        {
            get { return deviceItems; }
            set { deviceItems = value; }
        }
        private Timeline timeline;

        [XmlElement("timeline")]
        public Timeline Timeline
        {
            get { return timeline; }
            set { timeline = value; }
        }

        public Device GetItemByKey(string key)
        {
            foreach (Device device in deviceItems)
            {
                if (device.Id.Equals(key))
                    return device;
            }
            return null;
        }
    }
}
