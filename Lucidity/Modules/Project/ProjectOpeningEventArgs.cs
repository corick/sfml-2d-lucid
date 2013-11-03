using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucidity.Core.Project;
using Lucidity.Core.Project.Resources.TreeModel;

namespace Lucidity.Modules.Project
{
    public class ProjectOpeningEventArgs
        : EventArgs
    {
        public LucidityProject Project
        {
            get;
            private set;
        }

        public ProjectOpeningEventArgs(LucidityProject project)
        {
            Project = project;
        }
    }
}
