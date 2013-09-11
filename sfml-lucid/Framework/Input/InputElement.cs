using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Input
{
    //TODO: Doc me.
    public abstract class InputElement
    {
        private InputState state;

        /// <summary>
        /// Whether the input element is down.
        /// </summary>
        public bool Pressed
        {
            get { return state.Flags.HasFlag(InputStateFlags.Down); }
        }

        /// <summary>
        /// Whether or not the input element has changed between updates.
        /// </summary>
        public bool Edge
        {
            get { return state.Flags.HasFlag(InputStateFlags.Edge); }
        }

        /// <summary>
        /// The axis of the input element (if it is an axis element, like a joystick.)
        /// </summary>
        public short Axis
        {
            get { return state.Axis; }
        }

        public InputElement(bool useAxis = false)
        {
            state = new InputState(false, false, 0, useAxis);
            Update(); //In SFML We can read it right away, but this may not be the case always.
        }

        public void Update()
        {
            state = UpdateKeyState(state);
        }

        protected abstract InputState UpdateKeyState(InputState state);
    }
}
