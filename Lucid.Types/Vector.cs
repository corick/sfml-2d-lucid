
using System;
namespace Lucid.Types
{
    public struct Vector
    {
        private float _x;
        public float X 
        {
            get { return _x; }
            set { _x = value; }
        }

        private float _y;
        public float Y 
        {
            get { return _y; }
            set { _y = value; }
        }

        public Vector(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public static Vector Zero
        {
            get { return new Vector(0, 0); }
        }

        public float Dot(Vector other)
        {
            return (this.X * other.X) + (this.Y * other.Y);
        }

        public float Length()
        {
            return (float)Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector operator -(Vector v1)
        {
            return new Vector(-v1.X, -v1.Y);
        }

        //TODO: Lerps and stuff???
    }
}
