using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenRcp.Desktop.Exhibition.Domain;

namespace OpenRcp.Desktop.Exhibition.Parser
{
    public interface IExhibitionParser
    {
        Exhibition Parse(string file);
    }
}
