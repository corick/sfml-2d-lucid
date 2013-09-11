using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Input
{
    public interface IInputProvider
    {
        InputElement CreateBoundInputElement(string bindName);
    }
}
