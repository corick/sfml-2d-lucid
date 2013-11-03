using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Framework.Entities;
using Lucid.Framework.Entities.Components;
using Lucid.Framework.Graphics;

namespace TestGame.Entities
{
    public class TextTestComponent
        : Component
    {
        TextSprite sprite;

        public TextTestComponent(Entity parent)
            : base(parent)
        {
            sprite = new TextSprite("asdf", parent, 12, true);
        }

        public override void DisplayAttach(GraphicsContainer children)
        {
            children.Add(sprite);
        }

        public override void DisplayRemove(GraphicsContainer children)
        {
            children.Remove(sprite);
        }

        public override void Initialize(Lucid.Framework.Scene.Screen screen)
        {
        }
    }
}
