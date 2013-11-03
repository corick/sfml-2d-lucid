using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Models
{
    public class VisualizerProperty
    {
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
        public object PropertyDefaultValue { get; set; }
    }
}
