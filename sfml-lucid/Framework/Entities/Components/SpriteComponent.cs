using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Graphics;
using Lucid.Framework.Graphics.Sheet;

namespace Lucid.Framework.Entities.Components
{
    [DesignerName("Sprite")]
    [ComponentProperty("ResourcePath", typeof(string), "textures/missing.png")]
    public class SpriteComponent
        : Component
    {
        private UpdateNotifier update;
        private Sprite sprite;
        private string resPath;
        private Type resourceType;

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

        public override void DisplayAttach(GraphicsContainer parent)
        {
            parent.Add(sprite);
        }

        public override void DisplayRemove(GraphicsContainer parent)
        {
            parent.Remove(sprite);
        }

        public override void LoadResources(Resource.ResourceManager resources)
        {
            resourceType = resources.GetResourceType(resPath);
            if (resourceType == typeof(SpriteSheet))
            {
                sprite = new Sprite(resources.Load<SpriteSheet>(resPath), Parent.Bounds);
            }
            else if (resourceType == typeof(Texture))
            {
                sprite = new Sprite(resources.Load<Texture>(resPath), resPath, Parent.Bounds);
            }
            else throw new NotImplementedException("herp");
        }

        public override void UnloadResources(Resource.ResourceManager rsc)
        {
            //If we loaded it from a texture, we didn't acquire a SpriteSheet, we made one.
            //That means that we can't unload the sprite sheet (it's not the resource resPath
            //points to.
            if (resourceType == typeof(Texture))
                rsc.Release<Texture>(resPath);
            else if (resourceType == typeof(SpriteSheet))
                rsc.Release<SpriteSheet>(resPath);
            else throw new InvalidOperationException("Aaaa what");//FIXME: actually write a message.
        }

        public override void Destroy()
        {
            update.Update -= OnUpdate;
        }

        private void OnUpdate(object sender, UpdateEventArgs e)
        {
            //Update in the spritesheet.
        }
    }
}
