using Lucid.Framework.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Entities
{
    /// <summary>
    /// An Entity Manager. A container for Entity objects that are in the current Screen.
    /// </summary>
    public class EntityManager
        : IDisposable
    {
        private Screen owner;
        private List<Entity> entities;

        public EntityManager(Screen owner)
        {
            this.owner = owner;
            entities = new List<Entity>();
        }
        
        public void Add(Entity e)
        {
            e.Initialize(owner);
            entities.Add(e); //FIXME: Concurrent mod? I guess we never explicitly enumerate over it...
        }

        public void Dispose()
        {
            //FIXME: Do the IDisposable pattern right.
            entities.ForEach((Entity e) => { e.Dispose(); });
        }

    }
}
