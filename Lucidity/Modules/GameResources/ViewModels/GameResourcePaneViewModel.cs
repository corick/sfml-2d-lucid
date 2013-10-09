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

namespace Lucidity.Modules.GameResources.ViewModels
{
    public class GameResourcePaneViewModel
        : Tool, IHandle<ProjectClosingEventArgs>
    {
        private DocumentManager documents;

        private RootNodeViewModel resources;
        public RootNodeViewModel Resources 
        {
            get { return resources; }
            set { resources = value; NotifyOfPropertyChange(); }
        }

        public GameResourcePaneViewModel(ProjectManager project)
        {
            this.DisplayName = "Resources";
            this.Resources = new RootNodeViewModel(project.Project.Resources);

            IoC.Get<IEventAggregator>().Subscribe(this);
            documents = IoC.Get<DocumentManager>();
        }

        public override Gemini.Framework.Services.PaneLocation PreferredLocation
        {
            get { return Gemini.Framework.Services.PaneLocation.Left; }
        }

        public void Handle(ProjectClosingEventArgs message)
        {
            this.CloseCommand.Execute(null);
        }


    }
}
