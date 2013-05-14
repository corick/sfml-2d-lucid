using System;
using System.IO;

using Lucid.Framework.Graphics;

//SFML.Graphics.Texture is also a thing, so we should import both separately
//so I don't horribly confuse myself.
using SFMLTexture  = SFML.Graphics.Texture;
using LucidTexture = Lucid.Framework.Graphics.Texture;

namespace Lucid.Framework.Renderer.SFMLGraphics
{
    public class SFMLTextureProvider
        : ITextureProvider
    {
        public SFMLTextureProvider()
        {
        }
     
        /// <summary>
        /// Loads a texture from a file.
        /// </summary>
        /// <param name="file">The file path to load from, relative to the .</param>
        /// <returns>A Lucid.Framework.Graphics.Texture wrapping the sfml texture.</returns>
        public LucidTexture Load(string file)
        {
            SFMLTexture tex = new SFMLTexture(file);
            return CreateFromSFMLTexture(tex);
        }

        /// <summary>
        /// Loads a texture from a stream.
        /// </summary>
        /// <param name="stream">The stream to load the texture from.</param>
        /// <returns>A Lucid.Framework.Graphics.Texture wrapping the sfml texture.</returns>
        public LucidTexture Load(Stream stream)
        {
            return CreateFromSFMLTexture(new SFMLTexture(stream));
        }

        public void UnloadTexture(LucidTexture texture)
        {
            SFMLTexture tex = (texture.TextureData as SFMLTexture);
            tex.Dispose();
            //texture.TextureData = null;
        }

        private LucidTexture CreateFromSFMLTexture(SFMLTexture texture)
        {
            texture.Smooth = false; //FIXME: Get smoothing thing from config.
            TextureInfo tinfo = new TextureInfo((int)texture.Size.X, (int)texture.Size.Y);
            LucidTexture ret = new LucidTexture(tinfo, texture);
            return ret;
        }

    }
}
