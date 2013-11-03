using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lucidity.Core.Project.Resources
{
    /// <summary>
    /// A designer resource thingy.
    /// </summary>
    public class DesignerResource
    {
        /// <summary>
        /// The type of the resource (that it will be loaded as at runtime)
        /// </summary>
        public Type ResourceType 
        {
            get { return type; }
            set { type = value; }
        }
        private Type type;

        /// <summary>
        /// The time the resource was last modified.
        /// </summary>
        public DateTime LastModified 
        {
            get { return lastModified; }
            set { lastModified = value; }
        }
        private DateTime lastModified;

        /// <summary>
        /// The path of the resource's file in the local filesystem.
        /// </summary>
        public string FilePath 
        { 
            get { return filePath; }
            set { filePath = value; }
        }
        private string filePath;

        ///TODO: An 'importpath'. Soon we'll be able to do an "Update Imports"
        ///and it'll copy each updated file over.

        /// <summary>
        /// The unique identifier this resource uses.
        /// </summary>
        [JsonProperty]
        public Guid ResourceGuid
        {
            get;
            private set; //GUID should be somewhat-immutable.
        }

        [JsonConstructor]
        public DesignerResource(string filePath, Type type)
        {
            ResourceType = type;
            FilePath = filePath;
            ResourceGuid = Guid.NewGuid();
            Touch();
        }

        /// <summary>
        /// Updates the resources last modified time.
        /// </summary>
        public void Touch()
        {
            LastModified = DateTime.Now;
        }
    }
}
