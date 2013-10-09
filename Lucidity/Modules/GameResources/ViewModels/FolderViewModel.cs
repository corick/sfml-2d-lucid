using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;

using Lucidity.Core.Project.Resources.TreeModel;

namespace Lucidity.Modules.GameResources.ViewModels
{
    public class FolderViewModel
        : BaseNodeViewModel
    {
        public BindableCollection<BaseNodeViewModel> Children
        {
            get;
            set; //FIXME: Private set.
        }

        public FolderViewModel(FolderNode thisNode)
            : base(thisNode)
        {
            Children = new BindableCollection<BaseNodeViewModel>();
            AttachChildren();
        }

        /// <summary>
        /// Attach each res/thing subnode to this one??
        /// </summary>
        protected void AttachChildren()
        {
            foreach (var n in (node as FolderNode).Children)
            {
                if (n is FolderNode)
                    Children.Add(new FolderViewModel(n as FolderNode));
                else if (n is ResourceNode)
                    Children.Add(new ResourceViewModel(n as ResourceNode));
                else throw new InvalidOperationException("BUG: Wrong type of node!");
            }
        }
    }
}
