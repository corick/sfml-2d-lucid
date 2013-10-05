using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using LucidityCommon.Project.Resources;
using LucidityCommon.Project.Resources.TreeModel;

namespace Lucidity.Modules.GameResources.ViewModels
{
    public class ResourceViewModel 
        : BaseNodeViewModel
    {
        public Type ResourceType
        {
            get { return resource.ResourceType; }
            set { resource.ResourceType = value; NotifyOfPropertyChange(); }
        }

        private DateTime lastModified;
        public DateTime LastModified
        {
            get { return resource.LastModified; }
            set { resource.LastModified = value; NotifyOfPropertyChange(); }
        }

        private string filePath;
        public string FilePath
        {
            get { return resource.FilePath; }
            set { resource.FilePath = value; NotifyOfPropertyChange(); }
        }

        private DesignerResource resource
        {
            get { return (node as ResourceNode).Resource; }
        }

        public ResourceViewModel(ResourceNode node)
            : base(node)
        { }
    }
}
