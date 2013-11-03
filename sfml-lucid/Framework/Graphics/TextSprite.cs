using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Graphics
{
    public class TextSprite
        : IDisplayObject
    {
        public event EventHandler DepthChanged;

        public string Text
        {
            get;
            set;
        }

        public int Depth
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }

        public IPositionComponent Position
        {
            get;
            set;
        }

        public TextSprite(string text, IPositionComponent position, int depth = 0, bool visible=true)
        {
            Text = text;
            Position = position;
            Depth = depth;
            Visible = visible;
        }

        public void Initialize()
        {
            //Load te sprite here???
        }

        public void Draw(Graphics2D display)
        {
            display.DrawText(Text, null, Position.Position);
        }
    }
}
