using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

using Newtonsoft.Json;

namespace Lucid.Framework
{
    /// <summary>
    /// A dynamic dictionary. Like ExpandoObject, but less feature-full and with
    /// some more methods for interacting with json stuff.
    /// </summary>
    public class DynamicProperties 
        : DynamicObject
    {
        private Dictionary<string, object> table;

        public DynamicProperties()
        {
            table = new Dictionary<string, object>();
        }

        public void ImportProperties(ExpandoObject obj)
        {
            foreach (var property in obj)
            {
                if (table.ContainsKey(property.Key))
                    table[property.Key] = property.Value;
                else table.Add(property.Key, property.Value);
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (!table.ContainsKey(binder.Name))
                return false;
            result = table[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (table.ContainsKey(binder.Name))
                table[binder.Name] = value;
            else
                table.Add(binder.Name, value);
            return true;
        }
    }
}
