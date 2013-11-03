using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Framework;

namespace Lux
{
    internal class LuxGame
        : Lucid.Framework.Game
    {
        private string jsConfigPath;

        public LuxGame()
            : base()
        {
            //Set jsConfigPath to default of "default.properties"
#if DEBUG
            //if (System.Environment.GetCommandLineArgs().Contains<string>("-debug-attach"))
            System.Diagnostics.Debugger.Launch(); //better yet, read from properties.
#endif 
        }

        public LuxGame(string conf)
            : this()
        {
            jsConfigPath = conf;
            //TODO: Do sanity checking here; make sure we have a real cfg path.
        }

        //Read data from lux config.
        protected override void PreInitialize()
        {
            //Load config..
            if (jsConfigPath != null)
                ((Globals)globals).LoadConfig(jsConfigPath);
        }
    }
}
