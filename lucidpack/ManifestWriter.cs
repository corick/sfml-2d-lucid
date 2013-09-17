using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lucidpack
{
    internal class ManifestWriter
    {
        private List<string> entries;
        private LucidityCommon.Project.Resources.ResourceMapper map;

        public ManifestWriter()
        {
            entries = new List<string>();
            map = new LucidityCommon.Project.Resources.ResourceMapper();
        }

        public void Add(string path)
        {
            entries.Add(path + ">" + map.Map(path));
        }

        public void Add(string path, Type type)
        {
            entries.Add(path + ">" + type.FullName);
        }

        public string GetManifest()
        {
            StringBuilder b = new StringBuilder();
            entries.ForEach((e) => { b.Append(e); });
            return b.ToString();
        }
    }
}
