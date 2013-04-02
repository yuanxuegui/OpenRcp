using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OpenRcp.Desktop.Exhibition.Domain
{
    public class Device : IItemFinder<Operation, string>
    {
        private string idField;

        [XmlAttribute("id")]
        public string Id
        {
            get { return idField; }
            set { idField = value; }
        }
        private DeviceType typeField;

        [XmlAttribute("type")]
        public DeviceType Type
        {
            get { return typeField; }
            set { typeField = value; }
        }
        private Operation[] operationItemsField;

        [XmlElement("operation")]
        public Operation[] OperationItems
        {
            get { return operationItemsField; }
            set { operationItemsField = value; }
        }

        public Operation GetItemByKey(string key)
        {
            foreach (Operation operation in operationItemsField)
            {
                String opName = operation.Name;
                if (opName != null && opName.Equals(key))
                    return operation;
            }
            return null;
        }
    }
}
