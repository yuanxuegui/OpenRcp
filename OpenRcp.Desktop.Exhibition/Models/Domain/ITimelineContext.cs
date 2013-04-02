using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenRcp.Desktop.Exhibition.Domain
{
    public interface ITimelineContext : IPropertyFinder
    {
        void MergeProperties(Property[] properties);
        Area GetArea();
        Timeline GetTimeline();
    }
}
