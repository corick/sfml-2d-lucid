using System;
using System.Drawing;

namespace Lucid.Framework
{
    /// <summary>
    /// Kinda hacky- Allows us to pass this stuff between components and update / read from it in each.
    /// </summary>
    public interface IPositionComponent
    {
        Size RectSize
        {
            get;
            set;
        }

        Vector Position
        {
            get;
            set;
        }
    }
}
