using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lucid.Framework.Resource
{
    /// <summary>
    /// Provides methods for reading a manifest file from a lucid-pack file.
    /// </summary>
    internal class PackManifest
    {
        private Dictionary<string, Type> types;

        public PackManifest()
        {
            types = new Dictionary<string, Type>();
        }

        public void ReadManifest(Stream manifestStream)
        {
            StreamReader r = new StreamReader(manifestStream);

            while (!r.EndOfStream)
            {
                //Read each name>type line.
                string line = r.ReadLine();
                string[] p = line.Split('>');
                types.Add(p[0], Type.GetType(p[1], true, true));
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
    }
}
