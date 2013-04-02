using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OpenRcp.Desktop.Exhibition.Domain
{
    public class Timeline : IItemFinder<TimePoint,int>, IPropertyFinder
    {
        private Property[] propertyItemsField;

        [XmlElement("property")]
        public Property[] PropertyItem
        {
            get { return propertyItemsField; }
            set { propertyItemsField = value; }
        }
        private TimePoint[] timePointItemsField;

        [XmlElement("timePoint")]
        public TimePoint[] TimePointItems
        {
            get { return timePointItemsField; }
            set { timePointItemsField = value; }
        }

        public TimePoint GetItemByKey(int key)
        {
            foreach (TimePoint timePoint in timePointItemsField)
            {
                if (timePoint.Tick.Equals(key))
                {
                    return timePoint;
                }
            }
            return null;
        }

        public string GetPropertyValue(string name)
        {
            foreach (Property property in propertyItemsField)
            {
                if (name.Equals(property.Name))
                {
                    return property.Value;
                }
            }
            return null;
        }
    }
}
