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
        }

        public LuxGame(string conf)
            : this()
        {
            jsConfigPath = conf;
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
