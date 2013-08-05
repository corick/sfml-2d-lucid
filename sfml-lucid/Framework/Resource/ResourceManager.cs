using Lucid.Framework.Renderer;
using System;
using System.Collections.Generic;

namespace Lucid.Framework.Resource
{
    /// <summary>
    /// Manages a collection of IResourceReaders, does resource loading stuff.
    /// </summary>
    public class ResourceManager
        : IDisposable
    {
        private ZipPack resources;

        private Dictionary<Type, IResourceReader> readers;

        private ResourceCache cache;

        /// <summary>
        /// Creates a ResourceManager, and populates it with readers (manually for now.)
        /// </summary>
        /// <param name="packPath"></param>
        /// <param name="disp"></param>
        public ResourceManager(string packPath, IDisplayDevice disp)
        {
            //Create our PackFile
            resources = new ZipPack(packPath);
            readers = new Dictionary<Type, IResourceReader>();

            //Make our texture loader manually.
            //FIXME: This should not be right here. We need a better way to do this.
            Texture.TextureReader texReader = new Texture.TextureReader(disp.GetTextureProvider());
            AddReader(typeof(Graphics.Texture), texReader);

            cache = new ResourceCache();
        }

        public void AddReader(Type t, IResourceReader r)
        {
            readers.Add(t, r);
        }

        public T Load<T>(string path)
            where T : IResource
        {
            if (cache.IsCached(path))
            {
                return cache.Get<T>(path);
            }
            else
            {
                IResourceReader l = readers[typeof(T)];
                var rsc = l.LoadResource<T>(this, resources, path);
                cache.Cache<T>(path, rsc);
                return rsc;
            }
        }

        /// <summary>
        /// Decrements the reference count for the resource.
        /// Used for knowing when resources are safe to release from the resource cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="res"></param>
        public void Release<T>(string path)
            where T : IResource
        {
            cache.Release<T>(path, this);
        }

        public void Dispose() //Free each resource
        {
            cache.FreeAll(this);
        }
    }
}
