using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;
using Newtonsoft.Json;

namespace Lucidity.Core.Project.Resources.TreeModel
{
    /// <summary>
    /// A node. Can be either a folder or resource.
    /// </summary>
    public abstract class BaseNode
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        private BaseNode parent;
        [JsonIgnore]
        public BaseNode Parent
        {
            get { return parent; }
            set 
            {
                parent = value;
                OnPropertyChanged("Parent");
            }
        }

        private string name;
        public string DisplayName
        {
            get { return name; }

            set
            {
                name = value;
                OnPropertyChanged("DisplayName");
            }
        }

        //Creates a new RN.
        public BaseNode(BaseNode parent, string name)
        {
            this.parent = parent;
            this.name = name;
        }

        /// <summary>
        /// Build the resource path.
        /// </summary>
        /// <returns>The path to this node.</returns>
        public string GetResourcePath()
        {
            if (parent == null || parent is ResourceTree) return DisplayName;
            else return parent.GetResourcePath() + "/" + DisplayName;
        }

        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, args);
        }
    }
}
