using Lucid.Framework.Renderer;
using System;
using System.Collections.Generic;
using Lucid.Framework.Resource.Texture;
using Lucid.Framework.Graphics.Sheet;

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

            AddReader(typeof(SpriteSheet), new SpriteSheetReader());

            cache = new ResourceCache();
        }

        public void AddReader(Type t, IResourceReader r)
        {
            readers.Add(t, r);
        }

        public T Load<T>(string path)
            where T : IResource
        {
            var resolvedPath = Resolve(path);
            if (cache.IsCached(path)) //FIXME: Cache should only care bout guid.
            {
                return cache.Get<T>(resolvedPath);
            }
            else
            {
                IResourceReader l = readers[typeof(T)];
                var rsc = l.LoadResource<T>(this, resources, resolvedPath);
                cache.Cache<T>(resolvedPath, rsc);
                return rsc;
            }
        }

        public Type GetResourceType(string path)
        {
            return resources.GetResourceType(path);
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

        private string Resolve(string path)
        {
            //if it starts with id:// it's an id.
            //TODO: Fancy URI stuff
            //FIXME: Hacky.
            if (path.StartsWith("id://")) //FIXME: Garbagey
                return resources.GetResourcePath(path.Replace("id://", ""));
            else return path;
        }
    }
}
