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
            SimpleSpriteComponent c = new SimpleSpriteComponent(this);
            SimpleMoveCopmonent c2 = new SimpleMoveCopmonent(this);
            Components.Add(c);
            Components.Add(c2);
        }
    }
}
