using System;

using SDD = System.Diagnostics.Debug;

namespace Lucid.Framework
{
    public static class Debug
    {
        private static bool hasAttached = false;
        public static void Trace(string msg, params Object[] fmt)
#if DEBUG
        {
            //TODO: Log this as well.
            if (!hasAttached)
            {
                SDD.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Console.Out));
                hasAttached = true;
            }
            string dm = String.Format(msg, fmt);
            SDD.WriteLine(dm);
        }
#else
        {}
#endif
    }
}
