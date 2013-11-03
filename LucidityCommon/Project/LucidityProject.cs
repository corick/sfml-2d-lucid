using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.IO;

using Newtonsoft.Json;

using Lucidity.Core.Project.Resources;
using Lucidity.Core.Project.Resources.TreeModel;

namespace Lucidity.Core.Project
{
    public class LucidityProject //Is a model.
    {
        private const int CURRENT_VERSION = 1;

        private int version;
        public int Version
        {
            get { return version; }
            private set { version = value; }
        }

        private string name;
        /// <summary>
        /// The name of the project.
        /// This will be the window title in the game etc.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public string FilePath
        {
            get;
            set;
        }

        /// <summary>
        /// Each resource referenced in this game project.
        /// </summary>
        public ResourceTree Resources
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the root directory for the project.
        /// </summary>
        [JsonIgnore]
        public string RootDirectory
        {
            get { return Path.GetDirectoryName(FilePath); }
        }

        [JsonIgnore]
        public string CacheDirectory
        {
            get { return RootDirectory + @"\cache"; }
        }

        [JsonIgnore]
        public string PluginDirectory
        {
            get { return RootDirectory + @"\plugins"; }
        }

        [JsonIgnore]
        public string ResourcesDirectory
        {
            get { return RootDirectory + @"\resources"; }
        }

        /// <summary>
        /// The config stuff assoc with this. It gets loaded by the game.
        /// </summary>
        public dynamic Config; //Getter/setter?

        /// <summary>
        /// NEVER CALL THIS. Needed for json serializer.
        /// </summary>
        public LucidityProject() { } //HACK: We want the serializer to use this.

        /// <summary>
        /// Creates a new project with the given name.
        /// </summary>
        /// <param name="name"></param>
        public LucidityProject(string name, string filePath)
        {
            version = CURRENT_VERSION;
            Name = name;
            Resources = new ResourceTree();
            
            this.FilePath = filePath;
            CreateProjectDirectoryStructure(Path.GetDirectoryName(filePath));

            Config = new ExpandoObject(); //FIXME: We need to be able to remove these maybe??? 
            Config.AsdfAsdf = 1;
            Config.FsdaFsda = 2;
        }

        public void CreateProjectDirectoryStructure(string path)
        {
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(CacheDirectory);
            Directory.CreateDirectory(ResourcesDirectory);
            Directory.CreateDirectory(PluginDirectory);
            //And save the thing.
        }

        /// <summary>
        /// Creates a resources.lpz pack file 
        /// </summary>
        /// <param name="path">The full path to the file to create.</param>
        public void CreateResourcePack(string path)
        {
            var c = new Package.PackageCreator(Resources);
            c.CreatePackage(path);           
        }

        public static LucidityProject LoadFromFile(string filePath)
        {
            LucidityProject ret;
            JsonSerializer serializer = new JsonSerializer {TypeNameHandling = TypeNameHandling.Auto };
            using (var file = File.OpenRead(filePath))
            using (var reader = new StreamReader(file))
                ret = (LucidityProject)serializer.Deserialize(reader, typeof(LucidityProject));
            return ret;
        }

        public void SaveToFile()
        {
            JsonSerializer serializer = new JsonSerializer {TypeNameHandling = TypeNameHandling.Auto };
            serializer.Formatting = Formatting.Indented;
            //FIXME: Need to serialize private members.
            using (var file = File.Open(FilePath, FileMode.Create))
            using (var writer = new StreamWriter(file))
            {
                serializer.Serialize(writer, this);
            }
        }
    }
}
