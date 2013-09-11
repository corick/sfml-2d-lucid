using System;
using System.Drawing;
using Lucid.Framework.Graphics.Sheet;

//FIXME: minor: don't use SubRectangle, instead expose the Size in the sc so we don't call the getter.
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

        SpriteSheet spriteSheet;
        Animator animator;
        
        //Don't call me usually. 
        public Sprite(Texture texture, string texturePath, IPositionComponent position, int depth = 1) 
        {
            Visible = true;
            this.depth = depth;

            spriteSheet = new SpriteSheet(texture, texturePath);
            animator = spriteSheet.CreateAnimator();

            this.Position = position;
        }

        public Sprite(SpriteSheet sheet, IPositionComponent position, int depth = 1)
        {
            Visible = true;
            this.depth = depth;

            this.spriteSheet = sheet;
            this.Position = position;

            animator = spriteSheet.CreateAnimator();
            animator.SetAnimation("hit");
        }

        public virtual void Initialize()
        {
            if (Position.RectSize.Width  != animator.SubRectangle.Width
             || Position.RectSize.Height != animator.SubRectangle.Height)
            {
                //Set the size to the texture's size.
                Size s = new Size(animator.SubRectangle.Width, animator.SubRectangle.Height);
                Position.RectSize = s;
            }
        }

        public void Draw(Graphics2D gfx)
        {
            //FIXME: Color, etc render property stuff.
            gfx.DrawTexture(spriteSheet.SheetTexture, Position.Position, Position.RectSize, 
                            animator.SubRectangle, Camera, Color.White);

            //FIXME: We just want to see if this works...
            animator.Update(0.33f);
        }
    }
}
