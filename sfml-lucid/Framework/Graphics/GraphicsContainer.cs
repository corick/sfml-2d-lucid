using System;
using System.Collections.Generic;


namespace Lucid.Framework.Graphics
{
    public class GraphicsContainer
        : IGraphicsContainer
    {
        public event EventHandler DepthChanged;

        private List<IDisplayObject> displayObjects;
        private DisplayObjectComparer comparer;

        private int depth;
        /// <summary>
        /// The depth of this. Irrelevant for the root container
        /// </summary>
        public int Depth
        {
            get
            {
                return depth;
            }
            set
            {
                depth = value;
                //OnDepthChange(this, new EventArgs()); //I'm pretty sure this is wrong. We want to fire our own.
                if (DepthChanged != null) this.DepthChanged(this, new EventArgs());
            }
        }

        public bool Visible
        {
            get;
            set;
        }

        public GraphicsContainer(int depth = 1)
        {
            displayObjects = new List<IDisplayObject>();
            this.depth = depth;
            comparer = new DisplayObjectComparer();
        }

        public void Initialize() { } //Stub.

        /// <summary>
        /// Draws each to the screen.
        /// </summary>
        public void Draw(Graphics2D graphics)
        {
            foreach (var d in displayObjects)
            {
                d.Draw(graphics);
            }
        }

        public void Add(IDisplayObject o)
        {
            displayObjects.Add(o);
            displayObjects.Sort(comparer);
            o.DepthChanged += OnDepthChange;
            o.Initialize();
        }

        public void Remove(IDisplayObject o)
        {
            displayObjects.Remove(o);
            o.DepthChanged -= OnDepthChange;
        }

        //public void Clear() //FIXME: I don't think this should ever be added manually. That would probably make things bug out.
        //{
        //    //Clear the list. Unregister depth change events too!
        //    displayObjects.ForEach(
        //        (o) => 
        //        { 
        //            o.DepthChanged -= OnDepthChange; 
        //        }
        //    );

        //    displayObjects.Clear();
        //}

        //public void Dispose()
        //{
        //    Clear();
        //}

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
