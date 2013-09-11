using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;

namespace Lucid.Framework.Input.SFMLInput
{
    internal class SFMLInputProvider //FIXME: SFMLKeyInputProvider
        : IInputProvider
    {
        Dictionary<string, Keyboard.Key> bindings 
            = new Dictionary<string, Keyboard.Key>() //FIXME: Keyboard.Key[].
        {
            {"up", Keyboard.Key.Up},
            {"down", Keyboard.Key.Down},
            {"left", Keyboard.Key.Left},
            {"right", Keyboard.Key.Right},
            {"accept", Keyboard.Key.Z},
            {"cancel", Keyboard.Key.X},
            {"action", Keyboard.Key.Z},
            {"menu", Keyboard.Key.Q},
            {"use", Keyboard.Key.C}
        };

        public InputElement CreateBoundInputElement(string bindName)
        {
            //TODO: Use an Input Binder instead.

            var key = bindings[bindName];
            return new SFMLInputElement(key);
        }
    }
}
