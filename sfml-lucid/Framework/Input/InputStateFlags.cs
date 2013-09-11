using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Input
{
    [Flags]
    public enum InputStateFlags
        : byte
    { //FIXME: Make me part of InputState.
        /// <summary>
        /// Blank flags.
        /// </summary>
        None = 0,
        /// <summary>
        /// Whether or not the input element is pushed.
        /// For axis inputs, whether or not it's out of the deadzone.
        /// </summary>
        Down = 1,
        /// <summary>
        /// Whether or not the input has been changed this frame.
        /// For axis inputs, if the direction's sign has changed this is tset too.
        /// </summary>
        Edge = 2,
        /// <summary>
        /// Whether or not this should be treated like an axis input.
        /// </summary>
        Axis = 4
    }
}
