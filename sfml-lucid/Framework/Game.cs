using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Graphics;
using Lucid.Framework.Renderer;
using Lucid.Framework.Resource;

namespace Lucid.Framework
{
    /// <summary>
    /// The main game class for ... TODO DOC
    /// </summary>
    public class Game
    {
        private bool disposing;

        protected IWindow          window;
        //protected IDisplayDevice display;
        protected DisplayList      displayList;
        protected ResourceManager  resources;
        protected Graphics2D graphics;

        /// <summary>
        /// Creates a new Game instance ...
        /// </summary>
        public Game()
            : this(new Renderer.SFMLGraphics.SFMLWindow())
        {
            //TODO: We need to make a way to register display providers, and know which ones to prefer.
            //For now, since we only have the SFML one, we make one of those.
        }

        public Game(IWindow window)
        {
            disposing = false;
            this.window = window;
        }

        public void Run()
        {
            InternalInitialize();

            MainLoop();

            //Cleanup.
            window.Dispose();
        }



        protected virtual void Initialize() { }

        protected virtual void Update(float dt) { }

        protected virtual void Draw() { }

        private void InternalInitialize()
        {
            //Create subsystems.
            window.Initialize();
            IDisplayDevice display = window.DisplayProvider;
            
            //Initialize resource manager
            resources = new ResourceManager("resources.lpz", display);

            graphics = new Graphics2D(display);
            displayList = new DisplayList(graphics);
            
            Initialize();
        }

        private void InternalUpdate(float dt)
        {
            //Update each component.
            Update(dt);
        }

        private void InternalDraw()
        {
            //Do pre-drawing and post-drawing stuff!
            //Draw each component!
            Draw();
            //Take display list and throw it at the window.
            displayList.Draw();
        }

        private void MainLoop()
        {
            while (window.Running)
            {
                //Perform a tick!
                window.Update();

                float dt = GetDelta();
                InternalUpdate(dt);

                InternalDraw();

                window.Show();
            }
        }

        private float GetDelta()
        {
            return 0.033f; //FIXME: Do actual time delta calculation; 30fps for now.
        }

    }
}
