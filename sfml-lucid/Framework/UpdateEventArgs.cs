using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework
{
    public class UpdateEventArgs
        : EventArgs
    {
        public DateTime Time
        {
            get;
            private set;
        }

        public ulong FrameCount
        {
            get;
            private set;
        }

        public UpdateEventArgs(DateTime time, ulong frames)
        {
            Time = time;
            FrameCount = frames;
        }
    }
}
