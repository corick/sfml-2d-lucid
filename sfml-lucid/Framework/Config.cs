using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework
{
    /// <summary>
    /// Stub for now. Configuration file reader, exposes .cfg file as a 
    /// </summary>
    internal class Config
    {
        public Config()
            : this(@"lucid-framework.cfg")
        {
        }

        public Config(String path)
        {
            System.Diagnostics.Debug.WriteLine("Hey this isn't implemented yet.");
        }
    }
}
