using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Models;
using Lucidity.Core.Project.Resources.TreeModel;

namespace Lucidity.Core.Project.Resources
{
    public static class ResourceReferenceExtensions
    {
        public static DesignerResource Resolve(this ResourceReference reference, ResourceTree tree)
        {
            return tree.Find(reference.ReferenceID);
        }
    }
}
