using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Framework.Entities;
using Lucid.Framework.Entities.Components;
using Lucid.Types;

namespace TestGame.Entities
{
    internal class TestEntity
        : Entity
    {
        public TestEntity(EntityManager mgr)
             : base(mgr, new Transform(new Vector(300, 400), new Vector(0,0), new Vector(1.0f, 1.0f), 0f)) { }
            //: base(mgr) { }


        protected override void InitializeComponents()
        {
            SpriteComponent c = new SpriteComponent(this, @"spritesheet/kit.bss");
            SimpleMoveCopmonent c2 = new SimpleMoveCopmonent(this);
            var c3 = new TextTestComponent(this);
            Components.Add(c);
            Components.Add(c2);
            Components.Add(item: c3);

            LocalPosition = new Vector(0,0);
            LocalRotation = 0f;
            LocalScale = new Vector(1f, 1f);
            Origin = new Vector(16, 16);
        }
    }
}
