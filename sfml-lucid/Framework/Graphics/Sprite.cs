using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Graphics
{
    public class Sprite
        : IDisplayObject
    {
        public event EventHandler DepthChanged;

        private int depth;
        public int Depth
        {
            get { return depth; }
            set 
            { 
                depth = value;
                if (DepthChanged != null) 
                    DepthChanged(this, EventArgs.Empty);
            } 
        }

        private bool visible;
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Draw(IDisplayProvider display)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
