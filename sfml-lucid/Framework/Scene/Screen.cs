using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Entities;
using Lucid.Framework.Graphics;
using Lucid.Framework.Resource;

namespace Lucid.Framework.Scene
{
    /// <summary>
    /// An initialized screen object.
    /// </summary>
    public class Screen //Don't override this I think.
        : IDisposable
    {
        //FIXME: Service container instead.
        public ResourceManager Resources
        {
            get;
            private set;
        }

        public Services Services
        {
            get;
            private set;
        }

        public GraphicsContainer DipslayObjects
        {
            get;
            private set;
        }

        public EntityManager Entities
        {
            get;
            private set;
        }

        protected ScreenManager ScreenManager
        {
            get;
            private set;
        }

        public Screen()
        {
            ScreenManager = null;
            Entities = new EntityManager(this);
            DipslayObjects = new GraphicsContainer();
        }

        public void AttachTo(ScreenManager manager) //FIXME: This is called after attaching it.
        { //FIXME: Also just pass Serivces in I guess.
            Services = manager.Services;
            var displayList = Services.Get<GraphicsContainer>();
            displayList.Add(DipslayObjects);
            Resources = Services.Get<ResourceManager>();
            Debug.Trace("Attached {0} to the screen manager successfully.", this);
        }

        private bool disposed = false;
        public void Dispose()
        {
            Entities.Destroy(); //This should be enough to clean each up.
            //DipslayObjects.Dispose();
            //FIXME: Do this right.
            disposed = true;
        }
    }
}
