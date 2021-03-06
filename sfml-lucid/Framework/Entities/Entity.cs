﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Entities.Components;
using Lucid.Framework.Resource;
using Lucid.Framework.Scene;
using Lucid.Types;

namespace Lucid.Framework.Entities
{
    public abstract class Entity
        : Transform
    {
        protected List<Component> Components;

        public BoundingBox Bounds
        {
            get;
            set;
        }

        public Transform Transform
        {
            get { return Bounds.Transform; }
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

        public dynamic Properties
        {
            get;
            private set;
        }

        public Entity(EntityManager manager, Transform parent = null)
            : base(parent)
        {
            Manager = manager;
            Components = new List<Component>();
            Properties = new DynamicProperties();
            ID = manager.NextID();

            Bounds = new BoundingBox(this);
        }

        //TODO: Deserialization stuff??

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

        public void UnloadResources(Screen screen)
        {
            foreach (Component c in Components)
            {
                c.DisplayRemove(screen.DipslayObjects);
                c.UnloadResources(screen.Resources);
            }
        }

        /// <summary>
        /// Called by the EntityManager after removal. 
        /// Don't call this manually I think.
        /// </summary>
        public void Destroy()
        {
            //EM should call UnloadResources(rsc) then Cleanup() when this is
            //remove()'d.
            foreach (Component c in Components) c.Destroy();
        }
    }
}
