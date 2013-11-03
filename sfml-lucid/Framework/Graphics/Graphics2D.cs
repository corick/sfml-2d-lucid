using Lucid.Framework.Renderer;
using System;
using System.Drawing;
using Lucid.Types;
using System.Collections.Generic;

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
        
        //FIXME: Update to use Lucid.Types.
        //TODO: Default value for Camera.
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

        //FIXME: Camera stuff.
        public void DrawTexture(Texture texture, Transform transform, Rectangle source, Camera camera, Color color)
        {
            if (camera == null)
            {
                //FIXME: Cull offscreen objects.
                device.DrawTexture(texture, transform, source, color);
            }
            else
            {
                //FIXME: !!! Garbage!
                Transform tx = new Transform(transform, position:-camera.Offset, 
                                             scale: new Vector(1, 1), 
                                             origin: Vector.Zero,
                                             rotation: 0f);
                device.DrawTexture(texture, tx, source, color);
            }
        }

        //TODO: does basically the same as DrawIndexedPrimitives, gl
        public void DrawPrimitiveList(PrimitiveType type, List<Vector> vertices, Color color)
        {
            device.DrawPrimitives(type, vertices, color);
        }

        public void DrawText(string text, object font, Vector position) //FIXME: Color  too!@
        {
            device.DrawText(text, font, position, Color.White);
        }
    }
}
