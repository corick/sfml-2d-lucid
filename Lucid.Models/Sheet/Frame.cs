using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Models.Sheet
{
    public class Frame
    {
        public float Time //The time (in msec) to display.
        {
            get;
            private set;
        }

        public Point Position
        {
            get;
            private set;
        }

        public Frame(float time, Point position)
        {
            Time = time;
            Position = position;
        }
    }
}
