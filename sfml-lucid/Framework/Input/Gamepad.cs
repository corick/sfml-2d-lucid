using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Input
{
    public class Gamepad //TODO: Abstract.
    {
        private Dictionary<string, InputElement> inputElements;

        public Gamepad(IInputProvider input)
        {
            inputElements = new Dictionary<string, InputElement>();
            InitializeGamepad(input);
        }

        public bool Pressed(string key)
        {
            return inputElements[key].Pressed;
        }

        public bool Edge(string key)
        {
            return inputElements[key].Edge;
        }

        public short Axis(string key)
        {
            return inputElements[key].Axis;
        }

        /// <summary>
        /// Add your Input-s in here.
        /// </summary>
        protected void InitializeGamepad(IInputProvider input)
        {
            foreach (string s in //WOO HACK.
                new string[] {
                    "up", 
                    "down",
                    "left",
                    "right",
                    "accept",
                    "cancel",
                    "action",
                    "menu",
                    "use"
                })
                inputElements.Add(s, input.CreateBoundInputElement(s));
        }

        protected void AddInput(InputElement element, params string[] keys)
        {
            foreach(var k in keys) 
                inputElements.Add(k, element);
        }
    }
}
