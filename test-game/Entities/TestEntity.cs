using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Framework.Entities;
using Lucid.Framework.Entities.Components;

namespace TestGame.Entities
{
    internal class TestEntity
        : Entity
    {
        public TestEntity(EntityManager mgr)
            : base(mgr) { }


        protected override void InitializeComponents()
        {
            SpriteComponent c = new SpriteComponent(this, @"spritesheet/kit.bss");
            SimpleMoveCopmonent c2 = new SimpleMoveCopmonent(this);
            var c3 = new TextTestComponent(this);

            Components.Add(c);
            Components.Add(c2);
            Components.Add(item: c3);
        }
    }
}
