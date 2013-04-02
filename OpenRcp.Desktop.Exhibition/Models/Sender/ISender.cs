using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenRcp.Desktop.Exhibition.Sender
{
    public interface ISender
    {
        bool Send(string message);
    }
}
