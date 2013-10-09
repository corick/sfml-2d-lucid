using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;

using Gemini.Framework;
using Gemini.Framework.Results;
using Gemini.Framework.Services;

namespace Lucidity.Services
{
    [Export]
    public class DocumentManager //FIXME: Interface
    {
        [ImportMany]
        List<IEditorProvider> editors;

        public DocumentManager() { }

        public IDocument LoadFromFile(string fileName)
        {
            var editor = GetEditor(fileName);
            return editor.Create(fileName);
        }

        private IEditorProvider GetEditor(string fileName)
        {
            return editors.Find((e) => e.Handles(fileName));
        }
    }
}
