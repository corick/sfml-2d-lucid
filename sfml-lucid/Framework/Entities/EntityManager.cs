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
    {
        private Screen owner;
        private Dictionary<int, Entity> entities;
        private int currentID;

        //TODO: Indexer for ID.

        public EntityManager(Screen owner)
        {
            this.owner = owner;
            entities = new Dictionary<int, Entity>();
            currentID = 1000;
        }
        
        public void Add(Entity e)
        {
            e.Initialize(owner);
            entities.Add(e.ID, e); //FIXME: Concurrent mod? I guess we never explicitly enumerate over it...
        }

        public void Remove(Entity e)
        {
            Remove(e.ID);
        }

        public void Remove(int id)
        {
            var e = entities[id];
            entities.Remove(e.ID);
            e.UnloadResources(owner.Resources);
            e.Destroy();
        }

        public Entity Get(int id)
        {
            return entities[id];
        }

        //TODO: Maybe also include a SendMessage(string, object) function.

        /// <summary>
        /// Generates a unique Entity ID. 
        /// </summary>
        /// <returns>The next ID in the sequence.</returns>
        public int NextID()
        {
            int id;
            //This probably isn't necessary, but we need eids to be unique since they are a key.
            lock (this) 
            {
                id = ++currentID; 
            }
            return id;
        }

        public void Destroy()
        {
            for (int i = 0; i < entities.Count; i++) //Fixed concurrent mod.
            {
                var key = entities.Keys.First();
                Remove(key);
            }

        }
    }
}
