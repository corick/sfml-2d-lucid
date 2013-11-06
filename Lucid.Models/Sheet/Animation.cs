using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Models.Sheet
{
    /// <summary>
    /// A container for sprite sheet subrectangles.
    /// Manages time-step stuff as well.
    /// </summary>
    public class Animation
    {   
        private List<Frame> frames;

        public int FrameCount
        {
            get
            {
                return frames.Count;
            }
        }

        public string Key
        {
            get;
            private set;
        }

        public Animation(string key = "default-static")
        {
            this.frames = new List<Frame>();
            this.frames.Add(new Frame(0.0f, Point.Empty));
            this.Key = key;
        }

        public Animation(List<Frame> frames, string key)
        {
            this.frames = frames;
            this.Key = key;
        }

        public Point GetPoint(int index)
        {
            return frames[index].Position;
        }

        public Frame GetFrame(int index)
        {
            return frames[index];
        }
    }
}
