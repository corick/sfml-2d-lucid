using System;

using Lucid.Types;

namespace Lucid.Framework.Graphics
{
    public class Camera
    {
        public Vector Offset
        {
            get
            {
                return Vector.Zero;
            }
        }

        public IPositionComponent Following
        {
            get;
            set;
        }

        public void Update(float dt)
        {
            throw new NotImplementedException();
        }
    }
}
