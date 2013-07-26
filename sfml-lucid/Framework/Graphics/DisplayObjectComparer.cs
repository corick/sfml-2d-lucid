using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Graphics
{
    internal class DisplayObjectComparer
        : IComparer<IDisplayObject>
    {
        public int Compare(IDisplayObject x, IDisplayObject y)
        {
            return x.Depth.CompareTo(y.Depth);
        }
    }
}
