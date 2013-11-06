using System;
using System.Drawing;
using Lucid.Framework.Graphics.Sheet;
using Lucid.Types;

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
        /// The boundingbox of this sprite.
        /// </summary>
        public BoundingBox Bounds
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
        public Sprite(Texture texture, string texturePath, BoundingBox bounds, int depth = 1) 
        {
            Visible = true;
            this.depth = depth;

            this.spriteSheet = new SpriteSheet(texture, texturePath);
            animator = spriteSheet.CreateAnimator();
            this.Bounds = bounds;
        }

        public Sprite(SpriteSheet sheet, BoundingBox bounds, int depth = 1)
        {
            Visible = true;
            this.depth = depth;

            this.spriteSheet = sheet;
            this.Bounds = bounds;

            animator = spriteSheet.CreateAnimator();
            animator.SetAnimation("hit");
        }

        public virtual void Initialize()
        {
            if (Bounds.Width != animator.SubRectangle.Width
             || Bounds.Height != animator.SubRectangle.Height)
            {
                //Set the size to the texture's size.
                Bounds.Width = animator.SubRectangle.Width;
                Bounds.Height = animator.SubRectangle.Height;
            }

            //TODO: Set Origin
        }

        public void Draw(Graphics2D gfx)
        {
            //gfx.DrawTexture(spriteSheet.SheetTexture, Bounds.Transform.WorldPosition, new Size((int)Bounds.Width, (int)Bounds.Height), 
            //                animator.SubRectangle, Camera, Color.White);

            gfx.DrawTexture(spriteSheet.SheetTexture, Bounds.Transform, animator.SubRectangle, Camera, Color.White); 

            //FIXME: We just want to see if this works...
            animator.Update(0.33f);
        }
    }
}
