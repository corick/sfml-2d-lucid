using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Resource
{
    interface IAutoReference
    {
        void ReleaseAll(ResourceManager resourceManager);
    }
}
