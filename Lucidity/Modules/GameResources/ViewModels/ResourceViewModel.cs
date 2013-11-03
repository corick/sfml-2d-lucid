using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Gemini.Framework.Results;
using Lucidity.Core.Project.Resources;
using Lucidity.Core.Project.Resources.TreeModel;
using Lucidity.Services;
using Xceed.Wpf.Toolkit;

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
            get { return (Node as ResourceNode).Resource; }
        }

        public ResourceViewModel(BaseNodeViewModel parent, ResourceNode node)
            : base(parent, node)
        { }

        public IEnumerable<IResult> AddResource()
        {
            var pv = (Parent as FolderViewModel).Node as FolderNode;
            //FIXME: Show a dialog.
            yield return Show.Window(new GameResources.Dialogs.AddResourceDialogViewModel());
            pv.Children.Add(new ResourceNode(pv, new DesignerResource("herp", typeof(string))));
            (Parent as FolderViewModel).RefreshChildren();
            Parent.Refresh();
            yield break;
        }

        public IEnumerable<IResult> DeleteResource()
        {

            var message = String.Format("{0} will be deleted from disk and removed from the project.",
                                        Path.GetFileName(this.FilePath));
            var result = MessageBox.Show(message, "Delete Resource?", 
                                         System.Windows.MessageBoxButton.OKCancel);

            if (result == System.Windows.MessageBoxResult.Cancel)
                yield break;

            //FIXME: Delete the file on disk as well.

            var pv = (Parent as FolderViewModel).Node as FolderNode;
            pv.Children.Remove(this.Node);
            (Parent as FolderViewModel).RefreshChildren();
            yield break;
        }

        public IEnumerable<IResult> HandleOpen()
        {
            var documents = IoC.Get<DocumentManager>();
            var doc = documents.LoadFromFile(FilePath);
            yield return Show.Document(doc);
        }
    }
}
