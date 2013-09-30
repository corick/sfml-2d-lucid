using System;

using Lucid.Framework.Graphics;
using Lucid.Framework.Renderer;
using Lucid.Framework.Resource;
using Lucid.Framework.Scene;

using System.Reflection;
using System.Dynamic;
using Lucid.Framework.Input; //For debug message. Remove me :)

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
        protected Gamepad           gamepad;
        protected dynamic           globals; 

        //Add gamepad too.

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
            Debug.Trace("--corick <3");
            Debug.Trace("----");
            Debug.Trace("Creating Game.");

            Services = new Services();

            globals = new Globals();

            //FIXME: HACK: Don't manually add default properties.
            globals.ScreenWidth   = 800;
            globals.ScreenHeight  = 600;
            globals.ResourcesPath = "resources.lpz";
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
        protected virtual void PreInitialize() { }

        private void InternalInitialize()
        {
            PreInitialize();
            //Create subsystems.
            window.Initialize(); //TODO: WindowInitParams.
            IDisplayDevice display = window.DisplayDevice;

            //Initialize resource manager TODO: Read config for path.
            Debug.Trace("Loading lpz packfile from {0}.", globals.ResourcesPath);
            resources = new ResourceManager(globals.ResourcesPath, display);
            Services.Register<ResourceManager>(resources);

            Debug.Trace("Initializing services.");
            graphics = new Graphics2D(display);
            Debug.Trace("Graphics.");
            displayList = new GraphicsContainer();
            Services.Register<GraphicsContainer>(displayList); //Register the display list root.

            Debug.Trace("Gamepad.");
            Input.Gamepad gamepad = new Input.Gamepad(new Input.SFMLInput.SFMLInputProvider());
            Services.Register<Input.Gamepad>(gamepad);

            //Update notifier too!
            Debug.Trace("Update notifier.");
            updateNotifier = new UpdateNotifier();
            Services.Register<UpdateNotifier>(updateNotifier);

            Debug.Trace("Screen Manager.");
            screenManager = new ScreenManager(this);
            Services.Register<ScreenManager>(screenManager);


            Debug.Trace("Setting up default screen. (debug.)");
            //Let's set up the screen now.
            screenManager.SwitchScreen(new Screen());
            screenManager.EndFrame(); //Manually call this here. HACK.

            Debug.Trace("Initializing.");
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
