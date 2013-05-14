using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Resource
{
    public interface IResourceReader
    {
        Type ResourceType
        {
            get;
        }

        T LoadResource<T>(ZipPack from, string path);
    }
}
