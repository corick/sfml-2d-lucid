using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Graphics
{
    public class TextureInfo
    {
        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        //And other stuff?

        public TextureInfo(int w, int h)
        {
            Width = w;
            Height = h;
        }
    }
}
