using System;

using Lucid.Framework.Graphics;
using Lucid.Framework.Renderer;
using Lucid.Framework.Resource;
using Lucid.Framework.Scene;

using System.Reflection; //For debug message. Remove me :)

namespace Lucid.Framework
{
    /// <summary>
    /// The main game class for ... TODO DOC
    /// </summary>
    public class Game
        : IDisposable 
    {
        private bool disposed;

        //TODO: Find out which ones of these belong as services.
        protected IWindow           window;
        protected GraphicsContainer displayList;
        protected Graphics2D        graphics;
        protected ScreenManager     screenManager;
        protected UpdateNotifier    updateNotifier;
        protected ResourceManager   resources;

        public Services Services
        {
            get;
            private set;
        }

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
            disposed = false;
            this.window = window;
            Debug.Trace("Lucid: {0}.", Assembly.GetExecutingAssembly().ToString());
            Debug.Trace("----");
            Debug.Trace("Pre-Alpha.");
            Debug.Trace("--corick");
            Debug.Trace("----");
            Debug.Trace("Creating Game.");
            Services = new Services();
        }

        public void Run()
        {
            InternalInitialize();

            MainLoop();

            //Cleanup.
            this.Dispose();
            Debug.Trace("Resources (probably) successfully disposed.\nByeeeee!");
        }

        public void Dispose()
        {
            if (!disposed)
            {
                screenManager.CurrentScreen.Dispose();
                resources.Dispose();
                //Dispose graphics necessary?
                window.Dispose();
                disposed = true;
            }
        }

        protected virtual void Initialize() { }

        private void InternalInitialize()
        {
            //Create subsystems.
            window.Initialize();
            IDisplayDevice display = window.DisplayDevice;
            
            //Initialize resource manager TODO: Read config for path.
            Debug.Trace("Loading lpz packfile from resources.lpz.");
            resources = new ResourceManager("resources.lpz", display);
            Services.Register<ResourceManager>(resources);

            Debug.Trace("Initializing services.");
            graphics = new Graphics2D(display);
            displayList = new GraphicsContainer();
            Services.Register<GraphicsContainer>(displayList); //Register the display list root.

            //Update notifier too!
            updateNotifier = new UpdateNotifier();
            Services.Register<UpdateNotifier>(updateNotifier);

            screenManager = new ScreenManager(this);
            Services.Register<ScreenManager>(screenManager);

            //Let's set up the screen now.
            screenManager.SwitchScreen(new Screen());
            screenManager.EndFrame(); //Manually call this here. HACK.

            Initialize();
        }

        private void InternalUpdate(float dt)
        {
            //Fire the update notifier. 
            updateNotifier.FrameUpdate();
        }

        private void InternalDraw()
        {
            //Do pre-drawing and post-drawing stuff!
            //Draw each component!
            //Take display list and throw it at the window.
            displayList.Draw(graphics);
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
                screenManager.EndFrame();
            }
        }

        private float GetDelta()
        {
            return 0.033f; //FIXME: Do actual time delta calculation; 30fps for now.
        }

    }
}
