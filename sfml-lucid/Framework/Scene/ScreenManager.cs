using System;

using Lucid.Framework.Graphics;
using Lucid.Framework.Entities;
using Lucid.Framework.Resource;

namespace Lucid.Framework.Scene
{
    /// <summary>
    /// Manages scenes, scene transitions etc. 
    /// Also acts as a service container (so scenes can dispose content after running if needed.)
    /// </summary>
    public class ScreenManager
    {
        public Services Services
        {
            get;
            private set;
        }

        /// <summary>
        /// The current screen being managed by this screen manager.
        /// </summary>
        public Screen CurrentScreen
        {
            get;
            private set;
        }

        /// <summary>
        /// Internal use. The screen to be switched to next frame, or null if none.
        /// </summary>
        protected Screen NextScreen
        {
            get;
            private set;
        }

        public ScreenManager(Game game)
        {
            Services = game.Services;

            if (Services == null)
            {
                Debug.Trace("FATAL: Game is not initialized, so SceneManager can't grab the resources or display list.");
                throw new Exception("Can't initialize the scene manager. Resource or displaylist is null.");
            }
        }

        /// <summary>
        /// Begin transitioning to the next screen.
        /// </summary>
        /// <param name="next"></param>
        public void SwitchScreen(Screen next)
        {
            NextScreen = next;
        }

        /// <summary>
        /// Called after drawing.
        /// Performs a transition if needed.
        /// </summary>
        public void EndFrame() //FIXME: Clean me up a LOT. This is like a bad way to do this.
        {
            if (NextScreen != null)
            {
                //Dispose the current screen first.
                if (CurrentScreen != null) CurrentScreen.Dispose(); 

                NextScreen.AttachTo(this); //FIXME: Set the things manually too!

                CurrentScreen = NextScreen;
                NextScreen = null;
            }
        }
    }
}
