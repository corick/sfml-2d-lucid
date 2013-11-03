using System;
using System.Collections.Generic;
using System.Drawing;
using Lucid.Framework.Graphics;
using Lucid.Types;

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

        //TODO: DestScreen should be replaced with Vector, Scale??
        void DrawTexture(Texture texture, Rectangle destScreen, Rectangle source, Color color);

        //FIXME: Remove above DrawTexture...
        void DrawTexture(Texture texture, Transform transform, Rectangle source, Color color);

        void DrawPrimitives(PrimitiveType type, List<Vector> vertices, Color color);

        void DrawText(string text, object font, Vector position, Color color);
    }
}
