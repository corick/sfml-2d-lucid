using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Lucid.Types
{
    public class Transform
       // : IPositionComponent
    {
        private Transform parent;

        //TODO: Write our own matrix??
        private Matrix txCache = new Matrix();
        private Matrix transformMatrix
        {
            get
            {
                //FIXME: NOT OPTIMIZED AT ALL!!!!
                txCache.Reset();

                ///Compound transformations

                txCache.Scale(LocalScale.X, LocalScale.Y, MatrixOrder.Append);
                txCache.RotateAt(LocalRotation, new PointF(-Origin.X, LocalPosition.Y), MatrixOrder.Append);
                txCache.Translate(LocalPosition.X, LocalPosition.Y, MatrixOrder.Append);

                if (parent != null)
                {
                    txCache.Multiply(parent.transformMatrix, MatrixOrder.Append);
                }

                return txCache;
            }
        }

        private Vector positionOffset;
        /// <summary>
        /// Gets or sets the position of the object relative to the origin and the parent's 
        /// </summary>
        public Vector LocalPosition
        {
            get
            {
                return positionOffset;
            }
            set
            {
                positionOffset = value;
            }
        }

        public Vector WorldPosition
        {
            get
            {
                return LocalToWorld(LocalPosition);
            }
            set
            {
                positionOffset = WorldToLocal(value);
            }
        }

        private Vector scaleOffset;
        /// <summary>
        /// Gets or sets the scale of the object. 1.0 being normal.
        /// </summary>
        public Vector LocalScale
        {
            get
            {
                return scaleOffset;
            }
            set
            {
                scaleOffset = value;
            }
        }

        public Vector AbsoluteScale
        {
            get
            {
                ///Scale compounds.
                if (parent == null)
                    return LocalScale;
                else return new Vector(LocalScale.X * parent.AbsoluteScale.X,
                                       LocalScale.Y * parent.AbsoluteScale.Y);
            }
        }

        private float rotationOffset;
        /// <summary>
        /// Gets or sets the rotation about the origin.
        /// </summary>
        public float LocalRotation
        {
            get
            {
                return rotationOffset % 360;
            }
            set
            {
                rotationOffset = value;
            }
        }

        public float AbsoluteRotation
        {
            get
            {
                if (parent == null)
                    return LocalRotation;
                else return (LocalRotation + parent.AbsoluteRotation) % 360;
            }
        }

        private Vector originOffset;
        /// <summary>
        /// Gets or sets the origin of the transform relative to the 
        /// </summary>
        public Vector Origin
        {
            get
            {
                return originOffset;
            }
            set
            {
                originOffset = value;
            }
        }

        public Transform()
        {
            positionOffset = Vector.Zero;
            scaleOffset = new Vector(1, 1);
            rotationOffset = 0f;
            parent = null;
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
            this.scaleOffset = scale;
            this.rotationOffset = rotation;
        }

        public Transform(Transform parent, Vector position, Vector origin, Vector scale, float rotation)
            : this(position, origin, scale, rotation)
        {
            this.parent = parent;
        }


        private PointF[] ptCache = new PointF[1]; //FIXME: Remove this eventually! GROSS CODE
        /// <summary>
        /// Converts a point from local space to world space. 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector LocalToWorld(Vector point)
        {
            //Do translation, rotation around origin, scaling in the right order (e.g. not necessarily this one).
            //TODO: Matrix cache

            //PointF pt = new PointF(point.X, point.Y);
            PointF pt = new PointF( LocalPosition.X - point.X, LocalPosition.Y - point.Y);
            ptCache[0] = pt;
            transformMatrix.TransformPoints(ptCache);
            point.X = ptCache[0].X;
            point.Y = ptCache[0].Y;

            return point;
        }

        public Vector WorldToLocal(Vector point)
        {
            PointF pt = new PointF(point.X, point.Y);
            ptCache[0] = pt;
            var inv = transformMatrix;
            inv.Invert();
            inv.TransformPoints(ptCache);
            point.X = ptCache[0].X;
            point.Y = ptCache[0].Y;

            return point;
        }
    }
}
