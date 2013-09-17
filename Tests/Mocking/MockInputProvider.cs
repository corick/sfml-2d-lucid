using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucid.Framework.Input;

namespace Tests.Mocking
{
    public class MockInputProvider
        : IInputProvider
    {
        private class MockInputElement
            : InputElement
        {
            private S s;
            public MockInputElement()
            {
                s = S.D;
            }

            private enum S
            {
                DE, //depressed, edge
                D,  //...
                PE,
                P
            }

            //Cycles de - d - pe - p - ... ea update
            protected override InputState UpdateKeyState(InputState state)
            {
                return Transition(state);
            }

            private InputState Transition(InputState prev)
            {
                switch (s)
                {
                    case S.DE:
                        s = S.D;
                        return new InputState(false, prev);
                    case S.D:
                        s = S.PE;
                        return new InputState(false, prev);
                    case S.PE:
                        s = S.P;
                        return new InputState(true, prev);
                    case S.P:
                        s = S.DE;
                        return new InputState(true, prev);
                    default:
                        throw new Exception("not possible just making compiler happy");
                }
            }
        }

        public InputElement CreateBoundInputElement(string bindName)
        {
            return new MockInputElement();
        }
    }
}
