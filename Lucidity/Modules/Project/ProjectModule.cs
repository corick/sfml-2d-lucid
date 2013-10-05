using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

using Caliburn.Micro;
using Gemini.Framework;
using Gemini.Framework.Results;
using Gemini.Modules.MainMenu.Models;
using Lucidity.Project;
using LucidityCommon.Project;
using Lucidity.Modules.Project.ViewModels;
using System.Threading;

namespace Lucidity.Modules.Project
{
    [Export(typeof(IModule))]
    public class ProjectModule
        : ModuleBase
    {
        [Import]
        private ProjectManager manager;

        [Import]
        private IEventAggregator events;

        private ProjectSettingsViewModel settingsViewModel;

        public override void Initialize()
        {
            var fileMenu = MainMenu.First(x => x.Name == "File");
            fileMenu.Children.Insert(0, new MenuItem("New Project", CreateNewProject));
            fileMenu.Children.Insert(1, new MenuItem("Open Project", OpenProject));
            fileMenu.Children.Insert(2, new MenuItem("Save Project", SaveProject, () => manager.IsProjectLoaded)); //TODO: Probably get rid of these, and just update it auto.
            fileMenu.Children.Insert(3, new MenuItem("Close Project", CloseProject, () => manager.IsProjectLoaded));
            fileMenu.Children.Insert(4, new MenuItemSeparator());

            var projectMenu = MainMenu.First(x => x.Name == "Project");
            projectMenu.Add(new MenuItem("Test Game", RunGame, () => manager.IsProjectLoaded),
                            new MenuItemSeparator(),
                            new MenuItem("Project Settings", EditSettings, () => manager.IsProjectLoaded));

            //Only have one instance onf this.
            settingsViewModel = new ProjectSettingsViewModel(events, manager);
        }

        public IEnumerable<IResult> RunGame()
        {
            Launcher l = new Launcher(manager.Project); 

            ////Running this in a separate thread lets debugging stuff work properly,
            ////but we don't want the whole program to crash when the game crashes.
            ////Eventually we'll have a better solution for that.
            //Thread t = new Thread(new ThreadStart(l.Run));
            //t.Start();
            //while (t.IsAlive) //Freeze the UI. Hacky but whatever.
            //{
            //    Thread.Sleep(1000);
            //}
            l.Run(); //Launch it as a program instead.

            yield break;
        }

        /// <summary>
        /// Creates a new project ...
        /// </summary>
        /// <returns>Coroutine.</returns>
        public IEnumerable<IResult> CreateNewProject()
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.DefaultExt = "lproject";
            dialog.FileName = "lucidity";

            dialog.CreatePrompt = false;

            yield return Show.Dialog(dialog);

            //Create the project now. //FIXME: Show a custom window instead.
            LucidityProject p = new LucidityProject("Lucidity Project", dialog.FileName);
            manager.Project = p; //Load me :)
            manager.Project.SaveToFile();

            yield return PostLoadProject();

            yield break;
        }

        public IEnumerable<IResult> OpenProject()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            //dialog.DefaultExt = "lproject";
            //dialog.FileName = "lucidity";

            //dialog.Filter = "lproject";

            yield return Show.Dialog(dialog);

            LucidityProject p = LucidityProject.LoadFromFile(dialog.FileName);
            manager.Project = p;

            yield return PostLoadProject();

            yield break;
        }

        public IEnumerable<IResult> SaveProject()
        {
            manager.Project.SaveToFile(); //TODO: Let erryone know
            yield break;
        }

        public IEnumerable<IResult> CloseProject()
        {
            MainMenu.Refresh();
            yield return null;
        }

        public IEnumerable<IResult> EditSettings()
        {
            if (!settingsViewModel.IsActive) 
                yield return Show.Document(settingsViewModel);
            yield break; //TODO: Instead, focus it.
            //TODO: Make sure the title bar gets updated
        }

        private IResult PostLoadProject()
        {
            MainMenu.Refresh();
            return Show.Tool(new GameResources.ViewModels.GameResourcePaneViewModel(manager));
        }
    }
}
