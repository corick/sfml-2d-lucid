using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Lucidity.Core.Project.Resources.TreeModel;

namespace Lucidity.Modules.GameResources.ViewModels
{
    public class RootNodeViewModel
        : FolderViewModel
    {
        public override string DisplayName
        {
            get
            {
                return "Resources";
            }
            set
            {
                throw new InvalidOperationException("BUG: Shouldn't try to rename the resource root");
            }
        }

        public RootNodeViewModel(ResourceTree tree)
            : base(null, tree)
        {
            
        }

    }
}
