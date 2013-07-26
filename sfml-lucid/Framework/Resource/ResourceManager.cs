using Lucid.Framework.Renderer;
using System;
using System.Collections.Generic;

namespace Lucid.Framework.Resource
{
    /// <summary>
    /// Manages a collection of IResourceReaders, does resource loading stuff.
    /// </summary>
    public class ResourceManager
    {
        private ZipPack resources;

        private Dictionary<Type, IResourceReader> readers;

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
        }

        public void AddReader(Type t, IResourceReader r)
        {
            readers.Add(t, r);
        }

        public T Load<T>(string path)
        {
            //TODO: Resource caching -- Store resources in a <string, WeakReference> dictionary, and try to pull from there first.
            IResourceReader l = readers[typeof(T)];
            return l.LoadResource<T>(resources, path);
        }

        /// <summary>
        /// Decrements the reference count for the resource.
        /// TODO. This doesn't do anything yet. 
        /// Used for knowing when resources are safe to release from the resource cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="res"></param>
        public void DecrementCount<T>(T res)
        {
        }
    }
}
