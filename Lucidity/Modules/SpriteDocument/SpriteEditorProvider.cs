using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemini.Framework.Services;
using Lucidity.Modules.SpriteDocument.ViewModels;

namespace Lucidity.Modules.SpriteDocument
{
    [Export(typeof(IEditorProvider))]
    public class SpriteEditorProvider
        : IEditorProvider
    {
        public bool Handles(string path)
        {
            return Path.GetExtension(path)
                       .Equals(".jsheet", StringComparison.CurrentCultureIgnoreCase);
        }

        public Gemini.Framework.IDocument Create(string path)
        {
            return new SpriteEditorViewModel(path);
        }
    }
}
