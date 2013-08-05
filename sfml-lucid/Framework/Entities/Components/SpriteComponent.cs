using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Graphics;

namespace Lucid.Framework.Entities.Components
{
    public class SpriteComponent
        : Component
    {
        private UpdateNotifier update;
        private Sprite sprite;
        private string resPath;

        public SpriteComponent(Entity parent, string resPath)
            : base(parent) 
        {
                this.resPath = resPath;
        }

        public override void Initialize(Scene.Screen screen)
        {
            update = screen.Services.Get<UpdateNotifier>();
            update.Update += OnUpdate;
        }

        public override void LoadResources(Resource.ResourceManager resources)
        {
            resources.Load<Texture>(resPath);
        }

        public override void UnloadResources(Resource.ResourceManager rsc)
        {
            rsc.Release<Texture>(resPath);
        }

        public override void Destroy()
        {
            update.Update -= OnUpdate;
        }

        private void OnUpdate(object sender, UpdateEventArgs e)
        {
            //FIXME: Add update to sprite component here.
        }
    }
}
