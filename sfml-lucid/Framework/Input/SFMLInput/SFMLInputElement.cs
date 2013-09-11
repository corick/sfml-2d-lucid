using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;

namespace Lucid.Framework.Input.SFMLInput
{
    internal class SFMLInputElement
        : InputElement
    {
        private Keyboard.Key key;

        public SFMLInputElement(Keyboard.Key key)
        {
            this.key = key;
        }

        protected override InputState UpdateKeyState(InputState state)
        {
            return new InputState(Keyboard.IsKeyPressed(key), state);
        }
    }
}
