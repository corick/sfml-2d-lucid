using System;
using System.Collections.Generic;

namespace Lucid.Framework.Resource
{
    public class ResourceCache //FIXME: We need to be able to mark types non-cacheable.
    {
        private Dictionary<string, object> references; //FIXME: <..,IResource>.

        public ResourceCache()
        {
            references = new Dictionary<string, object>();
        }

        public bool IsCached(string path)
        {
            return references.ContainsKey(path);
        }

        public void Cache<T>(string key, T resource)
            where T : IResource
        {
            AutoReference<T> resourceRef = new AutoReference<T>(resource);
            references.Add(key, (object)resourceRef);
        }

        public T Get<T>(string path)
            where T : IResource
        {
            AutoReference<T> resourceRef = (AutoReference<T>)references[path];
            return resourceRef.Acquire();
        }       

        public void Release<T>(string path, ResourceManager parent)
            where T : IResource
        {
            AutoReference<T> resourceRef = (AutoReference<T>)references[path];
            resourceRef.Release(parent);
            if (resourceRef.InvalidReference)
                references.Remove(path);
        }

        public void FreeAll(ResourceManager parent)
        {
            //The reference count doesn't matter when the thing's done.
            foreach (var x in this.references)
            {
                (x.Value as IAutoReference).ReleaseAll(parent);
            }
        }

    }
}
