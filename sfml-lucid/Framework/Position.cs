using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework
{
    public class Position
        : IPositionComponent
    {
        public System.Drawing.Size RectSize
        {
            get;
            set;
        }

        Vector IPositionComponent.Position
        {
            get;
            set;
        }
    }
}
