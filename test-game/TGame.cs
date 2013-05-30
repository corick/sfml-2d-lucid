using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework;
using Lucid.Framework.Graphics;

namespace TestGame
{
    internal class TGame
        : Lucid.Framework.Game
    {
        private Texture tex;

        protected override void Initialize()
        {
            tex = this.resources.Load<Texture>(@"texture/test_image.png");

            Sprite sp = new Sprite(tex, new Position());
            sp.Position.Position = new Vector(30, 30);
            displayList.Add(sp);
        }

        protected override void Draw()
        {
        }
    }
}
