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

        public FolderViewModel(BaseNodeViewModel parent, FolderNode thisNode)
            : base(parent, thisNode)
        {
            Children = new BindableCollection<BaseNodeViewModel>();
            RefreshChildren();
        }

        //Reparent

        /// <summary>
        /// Attach each res/thing subnode to this one??
        /// </summary>
        public void RefreshChildren()
        {
            Children.Clear();
            foreach (var n in (Node as FolderNode).Children)
            {
                if (n is FolderNode)
                    Children.Add(new FolderViewModel(this, n as FolderNode));
                else if (n is ResourceNode)
                    Children.Add(new ResourceViewModel(this, n as ResourceNode));
                else throw new InvalidOperationException("BUG: Wrong type of node!");
            }
        }
    }
}
