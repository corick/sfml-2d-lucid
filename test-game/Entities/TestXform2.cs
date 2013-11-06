using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Framework;
using Lucid.Framework.Entities;
using Lucid.Framework.Entities.Components;
using Lucid.Types;

namespace TestGame.Entities
{
    public class TestXform2
        : Entity
    {
        public TestXform2(EntityManager manager, TestXform1 xf)
            : base(manager, xf)
        {
            this.LocalRotation = -10.0f;
            //TODO: Scalestuff.
            this.LocalScale = new Vector(0.5f, 0.5f);
            this.LocalPosition = new Vector(310, 0);
            this.Origin = new Vector(10, 10);

            Debug.Trace("xf2 (x:{0} y:{1})", WorldPosition.X, WorldPosition.Y);
        }

        protected override void InitializeComponents()
        {
            //Add new SpriteComponent
            SpriteComponent sc = new SpriteComponent(this, "texture/xftest.png");
            Components.Add(sc);
        }
    }
}
