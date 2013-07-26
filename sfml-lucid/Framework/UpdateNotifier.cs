using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework
{
    public class UpdateNotifier
    {
        public event EventHandler<UpdateEventArgs> Update;

        private ulong frames = 0;

        /// <summary>
        /// Fires the update event. Calculates time deltas and stuff as well.
        /// </summary>
        public void FrameUpdate()
        {
            DateTime time = DateTime.Now;

            //FIXME: this generates garbage.
            UpdateEventArgs a = new UpdateEventArgs(time, frames);

            if (Update != null) Update(this, a);
        }
    }
}
