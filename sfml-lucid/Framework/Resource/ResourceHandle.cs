using System;
using System.IO;
using System.IO.Compression;

namespace Lucid.Framework.Resource
{
    public class ResourceHandle
        : IDisposable
    {
        public Type ResourceType
        {
            get;
            private set;
        }

        public Stream ResourceStream
        {
            get;
            private set;
        }


        public ResourceHandle(ZipArchiveEntry entry, Type resType)
        {
            ResourceStream = entry.Open();
            ResourceType = resType;
        }

        public void Dispose()
        {
            this.ResourceStream.Dispose(); 
        }
    }
}
