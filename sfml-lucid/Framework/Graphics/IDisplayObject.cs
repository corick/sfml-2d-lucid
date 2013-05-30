using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Renderer;

namespace Lucid.Framework.Graphics
{
    /// <summary>
    /// A display object.
    /// </summary>
    public interface IDisplayObject
        : IDisposable
    {
        /// <summary>
        /// Fire this when the depth changes to notify containers that it's changed.
        /// </summary>
        event EventHandler DepthChanged;

        /// <summary>
        /// The depth to render it at (low = below)
        /// </summary>
        int Depth ///FIXME: Fire an event when my depth is changed!
        {
            get;
            set;
        }

        /// <summary>
        /// Wherther it's visible
        /// </summary>
        bool Visible
        {
            get;
            set;
        }

        //FIXME: Add camera things here!

        /// <summary>
        /// Sets up the object. Loads its resources (maybe) and whatnot.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Draws this display object to a Graphics2D reference.
        /// </summary>
        /// <param name="display">The g2d to draw it to.</param>
        void Draw(Graphics2D display); 
    }
}
