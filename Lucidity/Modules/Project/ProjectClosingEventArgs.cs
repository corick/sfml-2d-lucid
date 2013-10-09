using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucidity.Modules.Project
{
    /// <summary>
    /// Used to signal that the project is closing.
    /// </summary>
    public class ProjectClosingEventArgs
        : EventArgs
    {
        public ProjectClosingEventArgs()
        {
        }
    }
}
