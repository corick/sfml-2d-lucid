using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Types
{
    public class Transform
       // : IPositionComponent
    {
        //TODO: Maybe store this in a matrix??
        private Transform parent;

        private Vector positionOffset;
        public Vector Position
        {
            get;
            set;
        }

        private Vector sizeOffset;
        public Vector Scale
        {
            get;
            set;
        }

        private float rotationOffset;
        /// <summary>
        /// Gets or sets the rotation (in radians) about the 
        /// </summary>
        public float Rotation
        {
            get
            {
                if (parent == null) return rotationOffset;
                else return rotationOffset + parent.Rotation;
            }
            set
            {
                if (parent == null)
                {
                    rotationOffset = value;
                }
                else
                {
                    value -= parent.Rotation;
                    rotationOffset = value;
                }
            }
        }

        private Vector originOffset;
        public Vector Origin
        {
            get;
            set;
        }

        public Transform()
        {
            positionOffset = Vector.Zero;
            sizeOffset = Vector.Zero;
            rotationOffset = 0f;
        }

        public Transform(Transform parent)
            : this()
        {
            this.parent = parent;
        }

        public Transform(Vector position, Vector origin, Vector scale, float rotation)
            : this()
        {
            this.positionOffset = position;
            this.originOffset = origin;
            this.sizeOffset = scale;
            this.rotationOffset = rotation;
        }

        public Transform(Transform parent, Vector position, Vector origin, Vector scale, float rotation)
            : this(position, origin, scale, rotation)
        {
            this.parent = parent;
        }
    }
}
