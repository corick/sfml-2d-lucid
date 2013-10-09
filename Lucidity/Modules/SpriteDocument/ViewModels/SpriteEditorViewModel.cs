using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemini.Framework;

using Lucid.Framework.Graphics.Sheet;

namespace Lucidity.Modules.SpriteDocument.ViewModels
{
    /// <summary>
    /// The sprite editor document.
    /// </summary>
    public class SpriteEditorViewModel
        : Document
    {
        SpriteSheet sheet;

        public SpriteEditorViewModel(string filePath)
        {
            this.DisplayName = filePath;

            sheet = LoadSheet(filePath);
        }

        private SpriteSheet LoadSheet(string filePath)
        {
            return null;
        }

    }
}
