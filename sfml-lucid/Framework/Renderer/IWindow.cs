using System;
using System.Collections.Generic;

using System.Drawing;

namespace Lucid.Framework.Renderer
{
    /// <summary>
    /// Represents a window, etc. 
    /// </summary>
    public interface IWindow
        : IDisposable
    {
        /// <summary>
        /// The title of the window.
        /// </summary>
        String Title
        {
            get;
            set;
        }

        /// <summary>
        /// The of the usable part of the window (ie, not the top bar or border).
        /// </summary>
        Size WindowSize
        {
            get;
            set;
        }

        /// <summary>
        /// The event buffer for window events, like resize, and stuff.
        /// Remember to actually clear it!
        /// </summary>
        List<int> EventBuffer //FIXME: Should be a function, get...
        {
            get;
        }

        //TODO: SetIcon ...

        /// <summary>
        /// The display provider for this window. Manages texture loading and draw calls.
        /// Needs to be initialized first.
        /// </summary>
        IDisplayDevice DisplayDevice
        {
            get;
        }

        /// <summary>
        /// Whether or not the window has been exited.
        /// </summary>
        bool Running
        {
            get;
        }

        /// <summary>
        /// Initializes the window - creates the window, and the DisplayProvider.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Updates the window- polls its events etc.
        /// </summary>
        void Update();

        /// <summary>
        /// Draws the current frame to the screen.
        /// </summary>
        void Show();
    }
}
