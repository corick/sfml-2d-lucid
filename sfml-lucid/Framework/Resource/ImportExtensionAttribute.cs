using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Resource
{
    //FIXME: This is awful documentation.
    /// <summary>
    /// Defines the possible file extensions that a resource can be loaded from.
    /// Helps the 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ImportExtensionAttribute
        : Attribute
    {
        /// <summary>
        /// The file extensions that the resource can be loaded from.
        /// e.g.: Texture can be loaded from PNG files.
        /// </summary>
        public string[] Extensions
        {
            get;
            private set;
        }

        /// <summary>
        /// Which extensions are accepted by ...
        /// </summary>
        /// <param name="extensions">The file extensions (e.g. "png" not "*.png")</param>
        public ImportExtensionAttribute(params string[] extensions)
        {
            Extensions = extensions;
        }
    }
}
