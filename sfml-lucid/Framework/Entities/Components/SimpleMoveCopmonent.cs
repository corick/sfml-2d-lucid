using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Entities.Components
{
    public class SimpleMoveCopmonent
        : Component
    {
        public SimpleMoveCopmonent(Entity parent)
            : base(parent) {}

        UpdateNotifier tnref;

        public override void Initialize(Scene.Screen screen)
        {
            tnref = screen.Services.Get<UpdateNotifier>();
            tnref.Update += this.OnUpdate;

        }

        int xmod = 5;
        private void OnUpdate(object sender, UpdateEventArgs e)
        {
            if (Parent.Position.X > 800) xmod = -5;
            if (Parent.Position.X < 0) xmod = 5;

            Vector newPos = Parent.Position;
            newPos.X += xmod;
            Parent.Position = newPos;
        }

        public override void Dispose()
        {
            tnref.Update -= OnUpdate;
            base.Dispose();
        }
    }
}
