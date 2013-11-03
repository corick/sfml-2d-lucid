using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace Lucidity.Core.Project.Resources
{
    /// <summary>
    /// A list of resources (by path).
    /// </summary>
    public class ResourceList
    {
        public ObservableCollection<DesignerResource> Resources
        {
            get;
            private set;
        }

        public ResourceList()
        {
            Resources = new ObservableCollection<DesignerResource>();
        }
    }
}
