using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucidity.Core.Project.Resources
{
    internal class ManifestBuilder
    {
        private List<string> entries;
        private Lucidity.Core.Project.Resources.ResourceMapper map;

        public ManifestBuilder()
        {
            entries = new List<string>();
            map = new Lucidity.Core.Project.Resources.ResourceMapper();
        }

        public void Add(string path, DesignerResource resource)
        {
            entries.Add(path + ">" 
                      + resource.ResourceType.FullName + ">" 
                      + resource.ResourceGuid.ToString() + "\n");
        }

        public string GetManifest()
        {
            StringBuilder b = new StringBuilder();
            b.Append("#Lucid Manifest -- Auto generated\n");
            entries.ForEach((e) => { b.Append(e); });
            return b.ToString();
        }
    }
}
