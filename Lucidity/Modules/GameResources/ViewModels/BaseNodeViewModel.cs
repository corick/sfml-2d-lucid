using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;

using LucidityCommon.Project.Resources.TreeModel;

namespace Lucidity.Modules.GameResources.ViewModels
{
    public abstract class BaseNodeViewModel 
        : PropertyChangedBase, IHaveDisplayName
    {
        protected BaseNode node
        {
            get;
            private set;
        }

        public virtual string DisplayName
        {
            get { return node.DisplayName; }
            set { node.DisplayName = value; NotifyOfPropertyChange(); }
        }

        public BaseNodeViewModel(BaseNode node)
        {
            this.node = node;
        }

        //Baleet and stuff...
    }
}
