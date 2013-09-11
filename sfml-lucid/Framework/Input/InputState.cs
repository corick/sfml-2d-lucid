using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Input
{
    /// <summary>
    /// Represents the input state of the thingy.
    /// </summary>
    public struct InputState
    {
        /// <summary>
        /// The flags for this (e.g. Pressed?)
        /// </summary>
        public InputStateFlags Flags;
        public short Axis;

        public InputState(bool down, bool edge, short axis=0, bool useAxis = false)
        {
            Flags = InputStateFlags.None;
            if (down) Flags |= InputStateFlags.Down;
            if (edge) Flags |= InputStateFlags.Edge;
            Axis = axis;

            if (useAxis) Flags |= InputStateFlags.Axis;
        }

        public InputState(bool down, InputState prev, short axis=0)
        {
            //FIXME: Axis sign changes should trigger an edge too!
            Axis = axis;
            Flags = InputStateFlags.None;

            if (prev.Flags.HasFlag(InputStateFlags.Axis))
            {
                throw new NotImplementedException("Axis inputs aren't done yet.");
            }
            else 
            {
                //If our thing changed.
                if (prev.Flags.HasFlag(InputStateFlags.Down) != down)
                    Flags |= InputStateFlags.Edge;
                if (down) Flags |= InputStateFlags.Down;
            }

        }

    }
}
