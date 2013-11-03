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

        public Transform Transform
        {
            get { return transform; }
        }

        public float Width
        {
            get;
            set;
        }

        public float Height
        {
            get;
            set;
        }


        //TODO: Cache AABB.
        /// <summary>
        /// Gets the minimum aabb enclosing this.
        /// </summary>
        public BoundingRectangle Rectangle
        {
            get { throw new NotImplementedException(); }
        }

        public BoundingBox()
        {
            this.transform = new Transform();
        }

        public BoundingBox(Transform transform)
        {
            this.transform = transform;
        }

        public Vector GetIntersection(BoundingRectangle bound)
        {
            throw new NotImplementedException();
        }

        public Vector GetIntersection(BoundingBox other)
        {
            ///FIXME: Test delta.
            //Optimize for the Axis-Alignment case.
            //if (other.Transform.Rotation % (Math.PI / 2) == 0.0d)
            //    return GetIntersection(other.Rectangle);
            throw new NotImplementedException();
        }
    }
}
