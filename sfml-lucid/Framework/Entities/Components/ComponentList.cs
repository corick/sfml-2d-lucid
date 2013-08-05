using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Entities.Components
{
    internal class ComponentList
        : List<Component>, IDisposable
    {

        public void Dispose()
        {
            this.ForEach((Component c) => { c.Destroy(); });
        }
    }
}
