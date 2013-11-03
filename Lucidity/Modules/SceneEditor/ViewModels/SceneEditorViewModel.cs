using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemini.Framework;

namespace Lucidity.Modules.SceneEditor.ViewModels
{
    public class SceneEditorViewModel
        : Document
    {
        /// <summary>
        /// The scene we're working with.
        /// </summary>
        public SceneViewModel Scene
        {
            get { return scene; }
            set { scene = value; NotifyOfPropertyChange(); }
        }
        private SceneViewModel scene;

        public SceneEditorViewModel(string path)
        {
            //TODO: Load
        }
    }
}
