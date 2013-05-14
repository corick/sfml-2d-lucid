using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Graphics;

namespace Lucid.Framework.Resource.Texture
{
    public class TextureReader
        : IResourceReader
    {
        private ITextureProvider textureProvider;

        /// <summary>
        /// The resource type for a texture -- L.F.G.Texture
        /// </summary>
        public Type ResourceType
        {
            get { return typeof(Lucid.Framework.Graphics.Texture); }
        }

        public TextureReader(ITextureProvider textureProvider)
        {
            this.textureProvider = textureProvider;
        }

        public T LoadResource<T>(ZipPack from, string path)
        {
            using (ResourceHandle rh = from.GetFile(path))
                {
                if (typeof(T) == rh.ResourceType) //Let's make sure that we're returning a texture!
                {
                    object tex = textureProvider.Load(rh.ResourceStream);
                    return (T)tex;
                }
                else throw new InvalidOperationException("Type mismatch! Check your manifest.");
            }
        }
    }
}
