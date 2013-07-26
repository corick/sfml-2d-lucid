using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lucid.Framework.Renderer.SFMLGraphics
{
    /// <summary>
    /// The window for sfml.
    /// </summary>
    public class SFMLWindow
        : IWindow
    {
        private RenderWindow window;
        private List<int> eventBuf;

        public string Title
        {
            get
            {
                return "FIXME: Can't get title in SFML, use P/Invoke to grab it.";
            }
            set
            {
                window.SetTitle(value);
            }
        }

        public Size WindowSize //FIXME: Add null check!
        {
            get
            {
                var winSize = window.Size;
                return new Size((int)winSize.X, (int)winSize.Y);
            }
            set
            {
                window.Size = new SFML.Window.Vector2u((uint)value.Width, (uint)value.Height);
                //TODO: Figure out if this triggers reload-content stuff.
            }
        }

        public IDisplayDevice DisplayProvider
        {
            get;
            private set;
        }

        public List<int> EventBuffer { get; private set; } //stub

        public bool Running
        {
            get
            {
                return window.IsOpen();
            }
            
        }

        public SFMLWindow()
        {
            eventBuf = new List<int>();
        }

        public void Initialize() //TODO: Renderflags
        {
            window = new RenderWindow(VideoMode.DesktopMode, "Default-title", Styles.Close | Styles.Titlebar); //FIXME: Get from renderflags.

            window.Size = new Vector2u(800, 600); //FIXME: Get these from renderflags.
            window.SetFramerateLimit(30);

            //Now create a new view for this.
            //FIXME: Pull this, and the window size thing out from here to a SetWindowSize(w,h) function.
            //So we can change window size.
            //Set this up so pixels are 1:1 to internal coords.
            View pcView = new View(new FloatRect(0, 0, 800, 600));
            window.SetView(pcView);

            DisplayProvider = new SFMLDisplayDevice(this.window);
            window.Closed += OnClose;
        }

        SFML.Graphics.Color clearColor = new SFML.Graphics.Color(42,69,123);
        public void Update()
        {
            window.DispatchEvents();
            window.Clear(clearColor);
        }

        public void Show()
        {
            window.Display();
        }

        public void Dispose()
        {
            //todo: idisposable pattern
            window.Dispose();
            window.Closed -= OnClose;
            window = null;
            //TODO: destroy the display provider
        }

        private void OnClose(object sender, EventArgs e)
        {
            RenderWindow win = (RenderWindow)sender;
            win.Close();
        }
    }
}
