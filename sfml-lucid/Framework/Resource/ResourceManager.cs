using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Renderer;

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
    }
}
