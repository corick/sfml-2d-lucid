using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Resource;

namespace Lucid.Framework.Resource
{
    //Note: IResources must be immutabele, or override GetHashCode().
    public interface IResource
    {
        void OnUnload(ResourceManager res);
    }
}
