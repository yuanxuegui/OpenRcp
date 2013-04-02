using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using OpenRcp.Desktop.Exhibition.Sender;

namespace OpenRcp.Desktop.Exhibition.Domain
{
    public class Command : IExecutable, IPropertyFinder
    {
        private string deviceIdField;

        [XmlAttribute("deviceId")]
        public string DeviceId
        {
            get { return deviceIdField; }
            set { deviceIdField = value; }
        }
        private string operationNameField;

        [XmlAttribute("operationName")]
        public string OperationName
        {
            get { return operationNameField; }
            set { operationNameField = value; }
        }

        private Property[] propertyItemsField;

        [XmlElement("property")]
        public Property[] PropertyItems
        {
            get { return propertyItemsField; }
            set { propertyItemsField = value; }
        }


        public void Execute(ICommandContext commandContext)
        {
            SenderLocator.Lookup().Send(commandContext.BuildCommand(this));
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
