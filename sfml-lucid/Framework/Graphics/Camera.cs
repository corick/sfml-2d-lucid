using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
