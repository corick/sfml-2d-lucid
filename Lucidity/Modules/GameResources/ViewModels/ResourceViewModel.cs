using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Lucidity.Core.Project.Resources;
using Lucidity.Core.Project.Resources.TreeModel;
using Lucidity.Services;

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

        public DateTime LastModified
        {
            get { return resource.LastModified; }
            set { resource.LastModified = value; NotifyOfPropertyChange(); }
        }

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

        public void HandleOpen()
        {
            var documents = IoC.Get<DocumentManager>();
            var doc = documents.LoadFromFile(FilePath);
        }
    }
}
