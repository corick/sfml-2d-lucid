using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Models.Entity;

using Lucid.Models.Scene.SceneObject;

namespace Lucid.Models.Scene
{
    public class SceneModel
    {
        //TODO: SceneObjects. (Or are they gonna be entities?)
        //And Scripts (Figure out how to do later...)

        public List<Script.ScriptModel> Scripts;

        public List<SceneObjectBase> SceneObjects;

        public dynamic Globals //TODO: Find out how to expose defaults as browsable properties etc.
        {
            get;
            private set;
        }

        //Creates a Scene model.
        public SceneModel()
        {
            Globals = new ExpandoObject();
        }
    }
}
