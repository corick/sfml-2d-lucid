using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Graphics
{
    internal interface IGraphicsContainer
        : IDisplayObject
    {
        void Add(IDisplayObject o);
        void Remove(IDisplayObject o);
    }
}
