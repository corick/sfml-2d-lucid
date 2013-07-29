﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Resource
{
    /// <summary>
    /// A reference counting 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class AutoReference<T> 
        where T : IResource
    {
        private int refCount;
        private T reference; //FIXME: Do we need a weakref? We are manually managing the resource thing.

        public bool InvalidReference
        {
            get
            {
                return (refCount <= 0);
            }
        }

        public AutoReference(T resource)
        {
            reference = resource;
            refCount = 1;
        }

        public T Acquire()
        {
            refCount += 1;
            return reference;
        }

        public void Release(ResourceManager rsc)
        {
            refCount -= 1;

            if (refCount >= 0)
            {
                reference.Unload(rsc);
                reference = default(T);
            }
        }
    }
}
