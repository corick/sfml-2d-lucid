using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Entities.Components
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public class ComponentPropertyAttribute
        : Attribute
    {
        public Type PropertyType {get; private set;}
        public object PropertyDefaultValue {get; private set;}
        public string PropertyName { get; private set; }

        public ComponentPropertyAttribute(string propertyName, Type propertyType, object defaultVal = null)
        {
            PropertyType = propertyType;
            PropertyName = propertyName;
            PropertyDefaultValue = defaultVal;
        }

    }
}
