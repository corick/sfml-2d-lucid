using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Gemini.Framework;
using Lucidity.Core.Project.Resources;

namespace Lucidity.Modules.GameResources.Dialogs
{
    public class AddResourceDialogViewModel
        : PropertyChangedBase, IWindow
    {
        private string resourceName;
        public string ResourceName
        {
            get { return resourceName; }
            set { resourceName = value; NotifyOfPropertyChange(); }
        }

        private Type resourceType;
        public Type ResourceType
        {
            get { return resourceType; }
            set { resourceType = value; NotifyOfPropertyChange(); }
        }

        public AddResourceDialogViewModel()
        {
            ResourceName = "???";
            resourceType = typeof(string);
        }

        public IEnumerable<IResult> OkClicked()
        {
            //Set resource as result.
            yield break;
        }

        //IWindow Members...

        public void Activate()
        { 
        }

        public event EventHandler<ActivationEventArgs> Activated;

        public bool IsActive
        {
            get { return true; }
        }

        public event EventHandler<DeactivationEventArgs> AttemptingDeactivation;

        public void Deactivate(bool close)
        {
        }

        public event EventHandler<DeactivationEventArgs> Deactivated;
    }
}
