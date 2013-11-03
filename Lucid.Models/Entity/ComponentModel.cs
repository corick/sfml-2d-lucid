using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Types;

namespace Lucid.Models.Entity
{
    public class ComponentModel
    {
        //TODO: Properties

        public string DisplayName
        {
            get;
            private set;
        }

        public Type ComponentType
        {
            get;
            private set;
        }

        public ComponentModel(Type componentType)
        {
            DisplayName = (componentType.GetCustomAttributes(typeof(DesignerNameAttribute), true)
                          .First() as DesignerNameAttribute).DisplayName;

            //TODO: Properties = enumerate woo linq.
        }
    }
}
