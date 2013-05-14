using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework
{
    /// <summary>
    /// A display provider:
    /// Manages ui ticks, 
    /// </summary>
    public interface IDisplayProvider //TODO: Abstract class, so we can inherit the drawing logic!
    {
        /// <summary>
        /// Gets the texture provider associated with this Display Provider.
        /// </summary>
        /// <returns>The texture provider.</returns>
        ITextureProvider GetTextureProvider();

        //DisplayList {get; set;}

        //CreateCamera();

        //DrawSprite (source, destination, camera, renderprops)

        //DrawPrimitives (type, vertices)

        //DrawText
    }
}
