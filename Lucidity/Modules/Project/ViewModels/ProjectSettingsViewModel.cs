using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Gemini.Framework;
using Gemini.Framework.Results;
using Lucidity.Project;
using Lucidity.Services;

namespace Lucidity.Modules.Project.ViewModels
{
    public class ProjectSettingsViewModel
        : Document, IHandle<ProjectClosingEventArgs>
    {
        private readonly ProjectManager manager;
        private readonly IEventAggregator events;

        private string projectName = null;
        public string ProjectName
        {
            get 
            {
                if (projectName == null)
                    projectName = manager.Project.Name;
                return projectName; 
            }
            set
            {
                projectName = value;
                NotifyOfPropertyChange(() => ProjectName);
            }
        }

        [ImportingConstructor]
        public ProjectSettingsViewModel(IEventAggregator events, ProjectManager manager)
        {
            this.manager = manager;
            this.events = events;
            if (manager == null)
                throw new InvalidOperationException("!!! null project mgr");

            //if (manager.IsProjectLoaded == false)
            //    throw new InvalidOperationException("!!! project not loaded");

            events.Subscribe(this);
        }

        public void SaveSettings()
        {
            manager.Project.Name = projectName;
        }

        public void Handle(ProjectClosingEventArgs e)
        {
            //FIXME: Ask if you want to save.
            TryClose();
        }
    }
}
