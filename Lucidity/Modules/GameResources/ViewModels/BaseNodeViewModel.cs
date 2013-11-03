using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;

using Lucidity.Core.Project.Resources.TreeModel;

namespace Lucidity.Modules.GameResources.ViewModels
{
    public abstract class BaseNodeViewModel 
        : PropertyChangedBase, IHaveDisplayName, IChild<BaseNodeViewModel>
    {
        private BaseNodeViewModel parent;
        public BaseNodeViewModel Parent
        {
            get { return parent; }
            set { parent = value; NotifyOfPropertyChange(); }
        }

        public BaseNode Node
        {
            get;
            private set;
        }

        public virtual string DisplayName
        {
            get { return Node.DisplayName; }
            set { Node.DisplayName = value; NotifyOfPropertyChange(); }
        }

        public BaseNodeViewModel(BaseNodeViewModel parent, BaseNode node)
        {
            this.Node = node;
            this.Parent = parent;
        }

        //Baleet and stuff...

        object IChild.Parent
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = value as BaseNodeViewModel;
            }
        }
    }
}
