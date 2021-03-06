﻿using System;


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

        public T LoadResource<T>(ResourceManager resources, ZipPack from, string path)
        {
            using (ResourceHandle rh = from.GetFile(path))
            {
                if (typeof(T) == rh.ResourceType) //Let's make sure that we're returning a texture!
                {
                    try
                    {
                        object tex = textureProvider.Load(rh.ResourceStream);
                        return (T)tex;
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException("TextureReader: Couldn't load the resource from the stream.", e);
                    }
                }
                else throw new InvalidOperationException("TextureReader: Attempted to load the wrong resource type from this reader.");
            }
        }
    }
}
