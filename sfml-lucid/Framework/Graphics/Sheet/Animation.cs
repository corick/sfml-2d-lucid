using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Graphics.Sheet
{
    public class Animation
    {
        private const int FRAME_TIME_TICKS = 33 * 10000; //FIXME: This assumes that it's 33fps.

        private List<Frame> frames;
        private DateTime previousTime;
        private DateTime nextFrame;
        private int currentFrameIndex;

        public string Key
        {
            get;
            private set;
        }

        public Size AnimationSize
        {
            get;
            private set;
        }

        public Rectangle SubRectangle
        {
            get
            {
                return new Rectangle(frames[currentFrameIndex].Position, AnimationSize);
            }
        }

        public Animation(string key, List<Frame> frames, Size size)
        {
            Key = key;
            this.frames = frames;
            this.AnimationSize = size;
        }

        public void Update(DateTime time)
        {
            if (previousTime == DateTime.MinValue) 
                previousTime = time.AddTicks(-FRAME_TIME_TICKS);

            if (nextFrame.CompareTo(time) != -1)
            {
                //After next frame. Switch.
                nextFrame.AddTicks(FRAME_TIME_TICKS); //FIXME: This is wrong.

            }

            previousTime = time;
        }
    }
}
