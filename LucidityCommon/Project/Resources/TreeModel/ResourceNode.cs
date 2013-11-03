using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lucidity.Core.Project.Resources.TreeModel
{
    public class ResourceNode
        : BaseNode
    {
        private DesignerResource resource;
        public DesignerResource Resource
        {
            get { return resource; }
            set { resource = value; OnPropertyChanged("Resource"); }
        }

        [JsonConstructor]
        public ResourceNode(BaseNode parent, DesignerResource resource)
            : base(parent, Path.GetFileName(resource.FilePath))
        {
            this.Resource = resource;
        }
    }
}
