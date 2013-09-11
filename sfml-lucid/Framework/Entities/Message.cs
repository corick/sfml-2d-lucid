using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucid.Framework.Entities
{
    public class Message //TODO: Int keys for type???
    {
        public string Type
        {
            get;
            private set;
        }

        public object Content
        {
            get;
            private set;
        }

        public Message(string messageType, object message)
        {
            Type = messageType;
            Content = message;
        }
    }
}
