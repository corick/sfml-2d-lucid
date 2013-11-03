using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lucidity.Core.Project.Resources.TreeModel
{
    /// <summary>
    /// A node representing a folder in the resource fs.
    /// </summary>
    public class FolderNode
        : BaseNode
    {
        public readonly ObservableCollection<BaseNode> Children; //FIXME: Public???

        [JsonConstructor]
        public FolderNode(BaseNode parent, string name, IList<BaseNode> children)
            : base (parent, name)
        {
            Children = new ObservableCollection<BaseNode>(children); 
            Children.CollectionChanged += (s, e) => OnCollectionChanged(e);
        }

        /// <summary>
        /// Creates empty.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        public FolderNode(BaseNode parent, string name)
            : base(parent, name)
        {
            Children = new ObservableCollection<BaseNode>();
            Children.CollectionChanged += (s, e) => OnCollectionChanged(e);
        }

        /// <summary>
        /// Attempts to find the Resource Guid for a 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        protected DesignerResource FindByGuid(Guid guid)
        {
            foreach (var x in Children)
            {
                if (x is FolderNode)
                {
                    var res = (x as FolderNode).FindByGuid(guid);
                    if (res != null) return res;
                }
                else if (x is ResourceNode)
                {
                    if ((x as ResourceNode).Resource.ResourceGuid == guid)
                        return (x as ResourceNode).Resource;
                }
            }
            return null;
        }

        protected DesignerResource FindByFilePath(string path)
        {
            ///FIXME: Refactor this into findbyconditio nor something.
            ///Dry and whatnot.
            foreach (var x in Children)
            {
                if (x is FolderNode)
                {
                    var res = (x as FolderNode).FindByFilePath(path);
                    if (res != null) return res;
                }
                else if (x is ResourceNode)
                {
                    if ((x as ResourceNode).Resource.FilePath == path)
                        return (x as ResourceNode).Resource;
                }
            }
            return null;
        }

        protected void AddResources(List<ResourceNode> resources)
        {
            foreach (var c in Children)
            {
                if (c is ResourceNode)
                    resources.Add(c as ResourceNode);
                else (c as FolderNode).AddResources(resources);
            }
        }

        /// <summary>
        /// Reparents each child in this. 
        /// Needs to be done after deserialization, since I made some questionable design decisions.
        /// </summary>
        public void ReparentChildren() 
        {
            foreach (var c in Children)
            {
                if (c is FolderNode)
                    (c as FolderNode).ReparentChildren();
                c.Parent = this;
            }
        }
    }
}
