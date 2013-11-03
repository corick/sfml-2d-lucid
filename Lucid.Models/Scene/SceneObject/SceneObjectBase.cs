using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Types;

namespace Lucid.Models.Scene.SceneObject
{
    public abstract class SceneObjectBase
    {
        public string DisplayName
        {
            get;
            set;
        }

        public Vector Position
        {
            get;
            set;
        }
    }
}
