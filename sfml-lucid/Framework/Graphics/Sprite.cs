using System;
using System.Drawing;


namespace Lucid.Framework.Graphics
{
    public class Sprite //TODO: Add animation stuff.
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

        /// <summary>
        /// The absolute (non-camera-xlated) position of this sprite.
        /// </summary>
        public IPositionComponent Position
        {
            get;
            private set;
        }

        /// <summary>
        /// The camera that I'm parented to!
        /// </summary>
        public Camera Camera
        {
            get;
            set;
        }

        private Texture texture;

        protected Size  size;
        protected Point texOffset;

        public Sprite(Texture texture, IPositionComponent position, int depth = 1)
        {
            Visible = true;
            this.depth = depth;
            this.texture = texture;

            this.Position = position;

            //Set the h/w for this. It'll be re-set in the ctor for sprite sheets.
            size.Width = texture.Info.Width;
            size.Height = texture.Info.Height;
        }

        public virtual void Initialize()
        {
            if (Position.RectSize.Width  != size.Width
             || Position.RectSize.Height != size.Height)
            {
                //Set the size to the texture's size.
                Size s = new Size(texture.Info.Width, texture.Info.Height);
                Position.RectSize = s;
            }
        }

        public void Draw(Graphics2D gfx)
        {
            //FIXME: Color, etc render property stuff.
            gfx.DrawTexture(texture, Position.Position, Position.RectSize, new Rectangle(texOffset, size), Camera, Color.White);
        }

        public void Dispose()
        {
            //Don't dispose the texture here, I think. 
            //We're still using it in other sprites.
            Debug.Trace("Disposing this sprite!");
        }
    }
}
