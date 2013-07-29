using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Framework.Graphics;
using Lucid.Framework.Scene;

namespace Lucid.Framework.Entities.Components
{
    public class SimpleSpriteComponent
        : Component
    {
        protected Sprite sprite;
        protected string path = @"texture/test_image.png";

        public SimpleSpriteComponent(Entity parent)
            : base(parent) { }

        public override void Initialize(Screen screen) {}

        public override void LoadResources(Resource.ResourceManager rsc)
        {
            Texture tex = rsc.Load<Texture>(path);
            sprite = new Sprite(tex, Parent);           
        }

        public override void DisplayAttach(GraphicsContainer children)
        {
            children.Add(sprite);
        }

        public override void UnloadResources(Resource.ResourceManager rsc)
        {
            rsc.Release<Texture>(path);
        }
    }
}
