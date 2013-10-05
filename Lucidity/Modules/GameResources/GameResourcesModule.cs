using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemini.Framework;
using Gemini.Modules.MainMenu.Models;

namespace Lucidity.Modules.GameResources
{
    [Export(typeof(IModule))]
    public class GameResourcesModule
        : ModuleBase
    {
        [Import]
        Lucidity.Project.ProjectManager project;

        public override void Initialize()
        {
        }
    }
}
