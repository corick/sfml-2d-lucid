using Lucid.Framework.Renderer;
using System;
using System.Drawing;

namespace Lucid.Framework.Graphics
{
    /// <summary>
    /// Class that simplifies rendering for textures, sprites, etc.
    /// Does batching and stuff.
    /// Also allows primitive drawing.
    /// Note: primitive drawing with 
    /// </summary>
    public class Graphics2D
    {
        private IDisplayDevice device;

        /// <summary>
        /// The size of the viewport -- basically window size.
        /// </summary>
        public Rectangle Viewport
        {
            get;
            private set;
        }

        public Graphics2D(IDisplayDevice device)
        {
            this.device = device;
            Viewport = new Rectangle(0, 0, device.ViewportSize.Width, device.ViewportSize.Height);
        }
        

        public void DrawTexture(Texture texture, Vector position, Size size, Rectangle sourceRect, Camera camera, Color color)
        {
            Rectangle destRect;
            if (camera == null) //Don't translate the thing.
            {
                destRect = new System.Drawing.Rectangle((int)position.X, (int)position.Y, size.Width, size.Height);
            } 
            else //Camera is not null! Make sure this is within the viewport after xlating it.
            {
                destRect = new System.Drawing.Rectangle((int)(position.X + camera.Offset.X),
                                                        (int)(position.Y + camera.Offset.Y), 
                                                        size.Width, 
                                                        size.Height);
            }

            if (destRect.IntersectsWith(Viewport)) //If we're on the screen.
            {
                device.DrawTexture(texture, sourceRect, destRect, color);
            } 
        }

        //TODO: does basically the same as DrawIndexedPrimitives, gl
        public void DrawPrimitiveList(PrimitiveType type)
        {
            throw new NotImplementedException();
        }

        public void DrawText(string text, object font, Vector position)
        {
            throw new NotImplementedException();
        }
    }
}
