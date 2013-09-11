using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Graphics.Sheet
{
    public class Animator
    {
        private float elapsed;
        private Animation current;
        private Dictionary<string, Animation> animations;
        private int currentIndex;
        private Size size;

        public event EventHandler<EventArgs> Finished;

        public Rectangle SubRectangle
        {
            get
            {
                return new Rectangle(current.GetPoint(currentIndex), size);
            }
        }

        public Animator(Size size, Dictionary<string, Animation> animations)
        {
            this.size = size;
            this.animations = animations;
            var x = animations.Values.GetEnumerator();
            x.MoveNext();
            this.current = x.Current;
            Reset();
        }

        public void Update(float dt)
        {
            //FIXME: This is probably hella bugs.
            elapsed += dt;
            while (elapsed > current.GetFrame(currentIndex).Time) //Scoot forward a few frames.
            {
                float t = current.GetFrame(currentIndex).Time; 
                if (elapsed >= t)
                {
                    currentIndex += 1;
                    currentIndex %= current.FrameCount;
                    if (Finished != null && currentIndex == 0 && current.FrameCount != 1)
                        this.Finished(this, EventArgs.Empty);
                }
                elapsed -= t;
            }
        }

        public void SetAnimation(string key)
        {
            this.current = animations[key];
            Reset();
        }

        private void Reset()
        {
            elapsed = 0;
            //Among other things???
        }
    }
}
