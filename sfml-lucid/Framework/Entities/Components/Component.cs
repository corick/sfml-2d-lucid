using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Framework.Graphics;
using Lucid.Framework.Resource;
using Lucid.Framework.Scene;

namespace Lucid.Framework.Entities.Components
{
    /// <summary>
    /// A entity component, or a discrete part of an entity.
    /// </summary>
    public abstract class Component
        : IDisposable
    {
        /// <summary>
        /// The Entity that owns this componnet.
        /// </summary>
        protected Entity Parent
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates a new componnet attached to the parent entity.
        /// </summary>
        /// <param name="parent">The parent, owner.</param>
        public Component(Entity parent)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// Initializes the component. Does init logic stuff.
        /// </summary>
        /// <param name="screen">The screen to nab services from.</param>
        public abstract void Initialize(Screen screen); //FIXME: Pass services instead??

        /// <summary>
        /// Attaches any new graphics to the screen's display node.
        /// </summary>
        /// <param name="children">The display node to attach to.</param>
        public virtual void DisplayAttach(GraphicsContainer children) { }

        /// <summary>
        /// Loads any resources from the Resource Manager.
        /// </summary>
        /// <param name="rsc">Resource Manager to load from</param>
        public virtual void LoadResources(ResourceManager rsc) { }

        /// <summary>
        /// Called when Resources ned to be unloaded from the Resource Manager.
        /// </summary>
        /// <param name="rsc">Resource Manager to decrement resource counts on.</param>
        public virtual void UnloadResources(ResourceManager rsc) { }

        /// <summary>
        /// Called when the component is destroyed (eg when the Entity is disposed as well.)
        /// </summary>
        public virtual void Dispose() { }
    }
}
