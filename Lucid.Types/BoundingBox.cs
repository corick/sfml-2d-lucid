using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Types
{
    /// <summary>
    /// An OBB.
    /// </summary>
    public class BoundingBox
    {
        private Transform transform;



        public BoundingBox(Transform transform)
        {
            this.transform = transform;
        }

        public bool Intersects(BoundingRectangle bound)
        {
            throw new NotImplementedException();
        }
    }
}
