using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRcp.Desktop.Exhibition.Sender;

namespace OpenRcp.Desktop.Exhibition.Domain
{
    public interface ICommandContext
    {
        string BuildCommand(Command command);
    }
}
