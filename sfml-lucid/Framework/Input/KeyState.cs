using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Input
{
    /// <summary>
    /// The state of a key, currently.
    /// </summary>
    public struct KeyState
    {
        public KeyFlags Flags;
        public int ScanCode;
    }
}
