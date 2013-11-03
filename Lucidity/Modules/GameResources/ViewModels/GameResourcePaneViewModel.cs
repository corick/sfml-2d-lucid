using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Gemini.Framework;
using Lucidity.Modules.Project;
using Lucidity.Project;
using Lucidity.Services;
using Lucidity.Core.Project.Resources.TreeModel;
using Gemini.Framework.Results;
using System.ComponentModel.Composition;

namespace Lucidity.Modules.GameResources.ViewModels
{
    [Export(typeof(GameResourcePaneViewModel))]
    public class GameResourcePaneViewModel
        : Tool, IHandle<ProjectClosingEventArgs>, IHandle<ProjectOpeningEventArgs>
    {
        private DocumentManager documents;

        public RootNodeViewModel Resources 
        {
            get { return (RootNodeViewModel) RootSource[0]; }
            set 
            {
                if (RootSource.Count == 0)
                    RootSource.Add(value);
                else RootSource[0] = value; 
                NotifyOfPropertyChange(); 
            }
        }

        private BindableCollection<BaseNodeViewModel> rootSource;
        /// <summary>
        /// The root node as a collection. A little hack so the HierarchicalDataTemplate
        /// can bind to it.
        /// </summary>
        public BindableCollection<BaseNodeViewModel> RootSource
        {
            get { return rootSource; }
            private set { rootSource = value; NotifyOfPropertyChange(); }
        }

        public GameResourcePaneViewModel()
        {
            this.DisplayName = "Resources";
            IoC.Get<IEventAggregator>().Subscribe(this);
            documents = IoC.Get<DocumentManager>();
            this.RootSource = new BindableCollection<BaseNodeViewModel>();
        }

        public GameResourcePaneViewModel(ProjectManager project)
            : this()
        {
            this.Resources = new RootNodeViewModel(project.Project.Resources);
        }

        public override Gemini.Framework.Services.PaneLocation PreferredLocation
        {
            get { return Gemini.Framework.Services.PaneLocation.Left; }
        }

        public void Handle(ProjectOpeningEventArgs e)
        {
            this.Resources = new RootNodeViewModel(e.Project.Resources);
        }

        public void Handle(ProjectClosingEventArgs e)
        {
            //this.CloseCommand.Execute(null);
            this.Resources = null; //stop closing.
        }
    }
}
