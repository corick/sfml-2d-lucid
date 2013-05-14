using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace Lucid.Framework.Renderer.SFMLGraphics
{
    /// <summary>
    /// The display provider for sfml windows.
    /// </summary>
    internal class SFMLDisplayProvider
        : IDisplayProvider
    {
        private RenderWindow window;
        private ITextureProvider textureProvider;

        public SFMLDisplayProvider(RenderWindow window)
        {
            this.window = window;
            this.textureProvider = new SFMLTextureProvider();
        }

        public ITextureProvider GetTextureProvider()
        {
            return textureProvider;
        }
    }
}
