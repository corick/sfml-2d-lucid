
using Lucid.Framework.Graphics;
using System.Drawing;

namespace Lucid.Framework.Renderer
{
    /// <summary>
    /// A display provider:
    /// Manages ui ticks, 
    /// </summary>
    public interface IDisplayDevice //TODO: Abstract class, so we can inherit the drawing logic!
    {
        /// <summary>
        /// Gets the texture provider associated with this Display Provider.
        /// </summary>
        /// <returns>The texture provider.</returns>
        ITextureProvider GetTextureProvider();

        /// <summary>
        /// The size of the viewport this is attached to. 
        /// Not necessarily the same as the window's size.
        /// </summary>
        Size ViewportSize
        {
            get;
        }

        void DrawTexture(Texture texture, Rectangle destScreen, Rectangle source, Color color);

        //DrawPrimitives (type, vertices)

        //DrawText
    }
}
