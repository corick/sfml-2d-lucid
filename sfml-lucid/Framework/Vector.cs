
namespace Lucid.Framework
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

        //TODO: Dotprod, etc.
    }
}
