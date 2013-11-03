using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemini.Framework;
using Gemini.Framework.Results;
using Gemini.Modules.MainMenu.Models;
using Lucidity.Modules.GameResources.ViewModels;

using Caliburn.Micro;

namespace Lucidity.Modules.GameResources
{
    //Warning: Here Be Dragons.
    //I had no idea what I was doing.
    [Export(typeof(IModule))]
    public class GameResourcesModule
        : ModuleBase
    {
        [Import]
        Lucidity.Services.ProjectManager project;

        [Import]
        private GameResourcePaneViewModel viewModel;

        public override void PostInitialize()
        {
            this.MainMenu.First((m) => m.Name == "View").Add(
                new MenuItem("Resources", ShowTool, () => !viewModel.IsActive)
                );

            this.MainMenu.First((m) => m.Name == "Project").Add(
                new MenuItem("Import Resource", Import, () => project.IsProjectLoaded)
                );

            Coroutine.BeginExecute(ShowTool().GetEnumerator());
        }

        public IEnumerable<IResult> ShowTool()
        {
            yield return Show.Tool(viewModel);
        }

        public IEnumerable<IResult> Import()
        {
            yield return null;
        }
    }
}
