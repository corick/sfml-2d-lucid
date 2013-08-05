using System;

namespace Lucid.Framework.Resource
{
    public interface IResourceReader
    {
        Type ResourceType
        {
            get;
        }

        T LoadResource<T>(ResourceManager resources, ZipPack from, string path);
    }
}
