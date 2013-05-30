using System;

using SDD = System.Diagnostics.Debug;

namespace Lucid.Framework
{
    public static class Debug
    {
        public static void Trace(string msg, params Object[] fmt)
#if DEBUG
        {
            //TODO: Log this as well.
            string dm = String.Format(msg, fmt);
            SDD.WriteLine(dm);
        }
#else
        {}
#endif
    }
}
