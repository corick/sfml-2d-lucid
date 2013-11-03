using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucid.Models.Scene.SceneObject;
using Lucid.Types;
using Newtonsoft.Json;

namespace Lucid.Models.Entity
{
    /// <summary>
    /// A serialized Entity.
    /// Basically an Entity + all of its components (as Types) + its Property Table.
    /// Some reflection magic makes this a real Entity.
    /// </summary>
    public class SerializedEntityModel
        : SceneObjectBase
    {
        public List<Type> Components;
        public List<Script.ScriptModel> Scripts; 

        public dynamic PropertyTable
        {
            get;
            set;
        }

        /// <summary>
        /// Builds a basic one.
        /// </summary>
        public SerializedEntityModel()
        {
            Components = new List<Type>();
            Scripts = new List<Script.ScriptModel>();
        }

        /// <summary>
        /// Adds the default values for missing propertytable properties.
        /// </summary>
        public void AddDefaults()
        {
        }

        //TODO: From Template (.entity-template file)
    }
}
