using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;

using Lucid.Framework.Resource;

namespace Lucidity.Core.Project.Resources
{
    //NOTE: Must inject each assembly before calling or else custom resources will not be read.
    public class ResourceMapper
    {
        private Dictionary<string, Type> imports;

        public ResourceMapper()
        {
            imports = new Dictionary<string, Type>();
            PopulateImports();
        }

        public Type Map(string filePath)
        {
            var ext = Path.GetExtension(filePath);
            return imports[ext];
        }

        private void PopulateImports()
        {
            //FIXME: Don't do this manually.
            //Use reflection to grab each of the defined resources' ImportExtensionAttributes.
            imports.Add("png", typeof(Lucid.Framework.Graphics.Texture));
            imports.Add("bss", typeof(Lucid.Framework.Graphics.Sheet.SpriteSheet));
        }
    }
}
