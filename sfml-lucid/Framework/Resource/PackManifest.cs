using System;
using System.Collections.Generic;
using System.IO;

namespace Lucid.Framework.Resource
{
    /// <summary>
    /// Provides methods for reading a manifest file from a lucid-pack file.
    /// </summary>
    internal class PackManifest
    {
        private Dictionary<string, Type> types;
        private Dictionary<string, string> ids;

        public PackManifest()
        {
            types = new Dictionary<string, Type>();
            ids = new Dictionary<string, string>();
        }

        public void ReadManifest(Stream manifestStream)
        {
            StreamReader r = new StreamReader(manifestStream);

            while (!r.EndOfStream)
            {
                //Read each name>type line.
                string line = r.ReadLine();
                if (line[0] == '#') continue; //Skip comment lines.
                string[] p = line.Split('>');
                types.Add(p[0], Type.GetType(p[1], true, true));
                ids.Add(p[2], p[0]);
            }
        }

        /// <summary>
        /// Gets the type of a resource file, so we know what ResourceLoader to use to read it.
        /// </summary>
        /// <param name="file">The file to get the type for.</param>
        /// <returns>The type from the manifest, or null if no such file exists (and / or is not in the manifest).</returns>
        public Type GetFileType(string file)
        {
            return types[file];
        }

        //Gets a file by id.
        //Assumes the "id://" has been stripped from it.
        public string GetFileByID(string id)
        {
            return ids[id];
        }
    }
}
