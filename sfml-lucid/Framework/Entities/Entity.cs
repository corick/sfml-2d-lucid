using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Entities.Components;
using Lucid.Framework.Resource;
using Lucid.Framework.Scene;

namespace Lucid.Framework.Entities
{
    public abstract class Entity
        :IPositionComponent
    {
        protected List<Component> Components;

        public System.Drawing.Size RectSize
        {
            get;
            set;
        }

        public Vector Position
        {
            get;
            set;
        }

        public int ID
        {
            get;
            private set;
        }

        protected EntityManager Manager
        {
            get;
            private set;
        }

        public Entity(EntityManager manager)
        {
            Manager = manager;

            Position = Vector.Zero;
            RectSize = new System.Drawing.Size(0, 0);

            Components = new List<Component>();

            ID = manager.NextID();
        }

        protected abstract void InitializeComponents();

        public void Initialize(Screen screen)
        {
            InitializeComponents();

            Components.ForEach((Component c) => { c.Initialize(screen); });

            LoadResources(screen);
        }

        public void ReceiveMessage(Message message) 
        {
            foreach (Component c in Components)
                c.ReceiveMessage(message);
        }

        private void LoadResources(Screen screen)
        {
            foreach (Component c in Components)
            {
                c.LoadResources(screen.Resources);
                c.DisplayAttach(screen.DipslayObjects);
            }
        }

        public void UnloadResources(ResourceManager resources)
        {
            //FIXME: This doesn't work right now because of the way rsc is passed.
            foreach (Component c in Components) c.UnloadResources(resources);
        }

        public void Destroy()
        {
            //FIXME: Doesn't need to be Dispose(). Should be Cleanup().
            //EM should call UnloadResources(rsc) then Cleanup() when this is
            //remove()'d.
            foreach (Component c in Components) c.Destroy();
        }
    }
}
