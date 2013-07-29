using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Resource;

namespace Lucid.Framework.Resource
{
    public interface IResource
    {
        void Unload(ResourceManager rsc);
    }
}
