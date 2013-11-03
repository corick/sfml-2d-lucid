using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucidity.Core.Project.Resources.TreeModel
{
    /// <summary>
    /// Exposes a ResourceList as a tree.
    /// </summary>
    public class ResourceTree
        : FolderNode
    {
        public ResourceTree()
            : base(null, "Resources")
        {
        }

        /// <summary>
        /// Tries to find a resource by its specified GUID.
        /// </summary>
        /// <param name="guid">The GUID assigned to the resource.</param>
        /// <returns></returns>
        public DesignerResource Find(Guid guid)
        {
            return FindByGuid(guid);
        }

        public DesignerResource Find(string filesystemPath)
        {
            return FindByFilePath(filesystemPath);
        }

        public List<ResourceNode> GetResources()
        {
            List<ResourceNode> res = new List<ResourceNode>();
            AddResources(res);
            return res;
        }

    }
}
