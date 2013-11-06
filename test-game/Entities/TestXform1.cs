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
    public class TestXform1
        : Entity
    {
        public TestXform1(EntityManager manager)
            : base(manager)
        {
            this.LocalRotation = 20.0f;
            this.LocalScale = new Vector(0.5f, 1.2f);
            this.LocalPosition = new Vector(100, 100);
            this.Origin = new Vector(10, 10);

            Debug.Trace("xf1 (x:{0} y:{1})", WorldPosition.X, WorldPosition.Y);
        }

        protected override void InitializeComponents()
        {
            //Add new SpriteComponent
            SpriteComponent sc = new SpriteComponent(this, "texture/xftest.png");
            Components.Add(sc);
        }
    }
}
