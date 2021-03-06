﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Composition;

using Gemini.Framework;
using Gemini.Modules.MainMenu.Models;

namespace Lucidity.Modules.Init
{
    [Export(typeof(IModule))]
    public class InitModule 
        : ModuleBase
    {
        public override IEnumerable<IDocument> DefaultDocuments
        {
            get
            {
                return base.DefaultDocuments;
            }
        }

        public override void PreInitialize()
        {
            MainWindow.Title = "Lucidity Editor -- No Project Loaded";

            MainMenu.Insert(1, new MenuItem("Edit"));
            MainMenu.Add(new MenuItem("Project"));
        }

        public override void PostInitialize()
        {
            var menu = MainMenu.First(m => m.Name == "File").Children;
            menu.Remove(menu.First(m => m.Name == "Open"));
        }

    }
}
