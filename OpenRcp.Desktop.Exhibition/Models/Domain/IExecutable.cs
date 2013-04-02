using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenRcp.Desktop.Exhibition.Domain
{
    public interface IExecutable
    {
        void Execute(ICommandContext commandContext);
    }
}
