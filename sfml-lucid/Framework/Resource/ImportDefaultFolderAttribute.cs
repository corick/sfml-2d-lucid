using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Resource
{
    public class ImportDefaultFolderAttribute
        : Attribute
    {
        /// <summary>
        /// The name of the resource folder to load the resources into.
        /// </summary>
        public string FolderName
        {
            get;
            private set;
        }

        /// <summary>
        /// Designates a default folder to import resources of this type to.
        /// </summary>
        /// <param name="path">The path for the resources to be loaded to in the designer.</param>
        public ImportDefaultFolderAttribute(string path)
        {
            FolderName = path;
        }
    }
}
