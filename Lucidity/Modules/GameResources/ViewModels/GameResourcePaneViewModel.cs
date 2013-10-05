using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Gemini.Framework;
using Lucidity.Modules.Project;
using Lucidity.Project;
using LucidityCommon.Project.Resources.TreeModel;

namespace Lucidity.Modules.GameResources.ViewModels
{
    public class GameResourcePaneViewModel
        : Tool, IHandle<ProjectClosingEvent>
    {
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
        }

        public override Gemini.Framework.Services.PaneLocation PreferredLocation
        {
            get { return Gemini.Framework.Services.PaneLocation.Left; }
        }

        public void Handle(ProjectClosingEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
