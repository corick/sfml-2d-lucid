using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucidity.Core.Project;

namespace Lucidity.Services
{
    /// <summary>
    /// Handles loading and saving the project.
    /// Exported ...
    /// </summary>
    [Export]
    public class ProjectManager 
        : INotifyPropertyChanged//FIXME: Project stuff is laid out horribly.
    {
        private LucidityProject project;

        public LucidityProject Project
        {
            get { return project; }
            set
            {
                project = value;
                NotifyPropertyChanged("Project");
                NotifyPropertyChanged("IsProjectLoaded");
            }
        }

        /// <summary>
        /// Returns true if the project is loaded.
        /// Used for CanExecutes.
        /// </summary>
        public bool IsProjectLoaded
        {
            get { return Project != null; }
        }

        public ProjectManager()
        {
            Project = null;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
