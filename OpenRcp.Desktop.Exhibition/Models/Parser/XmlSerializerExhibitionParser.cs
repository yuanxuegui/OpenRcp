using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using OpenRcp.Desktop.Exhibition.Domain;
using OpenRcp.Desktop.Exhibition.Util;

namespace OpenRcp.Desktop.Exhibition.Parser
{
    public class XmlSerializerExhibitionParser : IExhibitionParser
    {
        public Exhibition Parse(string file)
        {
            return (Exhibition)XmlSerializerUtil.LoadXml(typeof(Exhibition), file);
        }
    }
}
