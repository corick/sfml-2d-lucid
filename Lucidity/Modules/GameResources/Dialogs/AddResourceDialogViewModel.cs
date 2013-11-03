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
        public DesignerResource Resource
        {
            get;
            private set;
        }

        public AddResourceDialogViewModel()
        {
            Resource = new DesignerResource("asdfdf", typeof(string));
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
