using System;
using System.Dynamic;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lucid.Framework 
{

    public class Globals 
        : DynamicProperties
    {
        public void LoadConfig(string jsConfigPath)
        {
            dynamic confParams = new ExpandoObject();
            using (var file = File.Open(jsConfigPath, FileMode.Open))
            using (var reader = new StreamReader(file))
            {
                JsonSerializer serializer = new JsonSerializer();
                confParams = serializer.Deserialize(reader, typeof(ExpandoObject));
            }

            //TODO: Whitelist properties here?? In serializer as a schema???
            //As it is right now we can just put whatever we want in the config.

            ImportProperties(confParams as ExpandoObject);
        }
    }
}
