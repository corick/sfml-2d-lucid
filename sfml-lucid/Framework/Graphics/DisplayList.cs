using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Renderer;

namespace Lucid.Framework.Graphics
{
    public class DisplayList
    {
        private Graphics2D graphics;
        private List<IDisplayObject> displayObjects;

        public DisplayList(Graphics2D graphics)
        {
            this.graphics = graphics; //sad i removed a pun here
            displayObjects = new List<IDisplayObject>();
        }

        /// <summary>
        /// Draws each to the screen.
        /// </summary>
        public void Draw()
        {
            foreach (var d in displayObjects)
            {
                d.Draw(graphics);
            }
        }

        public void Add(IDisplayObject o)
        {
            displayObjects.Add(o);
            displayObjects.Sort();
            o.DepthChanged += OnDepthChange;
        }

        public void Remove(IDisplayObject o)
        {
            displayObjects.Remove(o);
            o.DepthChanged -= OnDepthChange;
        }

        public void Clear(bool andDispose = false)
        {
            //Clear the list. Unregister depth change events too!
            displayObjects.ForEach(
                (o) => 
                { 
                    if (andDispose) 
                            o.Dispose();
                    o.DepthChanged -= OnDepthChange; 
                }
            );

            displayObjects.Clear();
        }

        public void Dispose()
        {
            Clear(true);
        }

        /// <summary>
        /// A contained display object's depth has changed!
        /// Re-sort them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDepthChange(object sender, EventArgs e)
        {
            displayObjects.Sort();
        }
    }
}
