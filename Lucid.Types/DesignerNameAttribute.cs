using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Types
{
    /// <summary>
    /// Used to tell the editor what to call an object in the property browser.
    /// Also used to give friendly names for types in formatting related stuff.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited=true, AllowMultiple=false)]
    public class DesignerNameAttribute
        : Attribute
    {
        /// <summary>
        /// The name to put in designer stuff.
        /// </summary>
        public string DisplayName
        {
            get;
            private set;
        }

        public DesignerNameAttribute(string name)
        {
            DisplayName = name;
        }
    }
}
