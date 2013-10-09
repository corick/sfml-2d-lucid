using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Lucidity.Core.Project;
using Newtonsoft.Json;

namespace Lucidity.Project
{
    internal class Launcher
    {
        private LucidityProject project;

        public Launcher(LucidityProject project)
        {
            this.project = project;
        }

        public void Run()
        {
            //Create package for lpz.
            string lpzPath = Path.GetTempFileName(); //TODO: store these in cache dir.
            string confPath = Path.GetTempFileName();

            //FIXME: Hack: We set the resources path manually each time.
            project.Config.ResourcesPath = lpzPath;
            project.CreateResourcePack(lpzPath);
            CreateConfig(confPath);

            try
            {
                // Lux.Program.Launch(confPath);
                var p = Process.Start("Lux.exe", confPath);
                p.WaitForExit();
            }
            finally
            {
                //Cleanup our temp files.
                //FIXME: Cache these instead of generating them each time.
                File.Delete(lpzPath);
                File.Delete(confPath);
            }
        }

        private void CreateConfig(string path)
        {
            //FIXME: DRY; pull this out into project?
            using (StreamWriter fs = new StreamWriter(File.Open(path, FileMode.Open)))
            using (JsonTextWriter jt = new JsonTextWriter(fs))
            {
                JsonSerializer jserializer = new JsonSerializer();
                jserializer.Serialize(jt, project.Config);
            }

        }
    }
}
