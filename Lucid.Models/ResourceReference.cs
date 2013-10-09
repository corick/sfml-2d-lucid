using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Lucid.Models
{
    public class ResourceReference
    {
        [JsonProperty]
        public Guid ReferenceID
        {
            get;
            private set;
        }

        public ResourceReference()
        {
            ReferenceID = Guid.Empty;
        }
    }
}
