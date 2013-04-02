using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRcp.Desktop.Exhibition.Domain;

namespace OpenRcp.Desktop.Exhibition.Engine
{
    public interface ITimelineEngine
    {
        void Init(ITimelineContext timelineContext);
        void Start();
        void Pause();
        void Stop();
        void Go(int timeTicked);
        event Func<int, bool> TimeTickEvent;
    }
}
