using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemini.Framework;
using Gemini.Framework.Services;

namespace Lucidity.Modules.SceneEditor
{
    /// <summary>
    /// Editor provider for Scene editor.
    /// </summary>
    [Export(typeof(IEditorProvider))]
    public class SceneEditorProvider
        : IEditorProvider
    {
        public bool Handles(string path)
        {
            return Path.GetExtension(path)
                       .Equals(".lsd", StringComparison.CurrentCultureIgnoreCase);
        }

        public IDocument Create(string path)
        {
            return new SceneEditor.ViewModels.SceneEditorViewModel(path) as IDocument;
        }
    }
}
