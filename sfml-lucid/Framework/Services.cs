using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework
{
    public class Services
    {
        private Dictionary<Type, object> services;

        public Services()
        {
            services = new Dictionary<Type, object>();
        }

        public void Register<T>(T svc)
        {
            if (services.ContainsKey(typeof(T)))
                throw new Exception("Error: Can't add the same service twice.");
            else services.Add(typeof(T), svc);
        }

        public T Get<T>()
        {
            //TODO: Error message.

            return (T)services[typeof(T)];
        }
    }
}
