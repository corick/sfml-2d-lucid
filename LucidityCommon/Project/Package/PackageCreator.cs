using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Compression;

using Lucidity.Core.Project.Resources;
using Lucidity.Core.Project.Resources.TreeModel;

namespace Lucidity.Core.Project.Package
{
    /// <summary>
    /// Creates a lpz package.
    /// </summary>
    internal class PackageCreator
    {
        private ResourceTree resourceTree;
        public PackageCreator(ResourceTree resources)
        {
            this.resourceTree = resources;
        }

        /// <summary>
        /// Creates a package file from the given resources.
        /// </summary>
        /// <param name="path">The path for the package file to create.</param>
        public void CreatePackage(string path)
        {
            ///Start! Add the files to a zip file.
            
            //TODO: Shove this into UpdatePackage, and make this delete the pack before runnign.
            using (var lpz = new FileStream(path, FileMode.Create)) 
            using (var zip = new ZipArchive(lpz, ZipArchiveMode.Update, true))
            {
                CreateManifest(zip); //CreateOrUpdate ...

                foreach (var r in resourceTree.GetResources())
                {
                    CreateFile(zip, r as ResourceNode);
                }

            }
            
        }

        /// <summary>
        /// Updates an existing .lpz packfile.
        /// </summary>
        /// <param name="path">The path to the pack to update.</param>
        public void UpdatePackage(string path)
        {
            throw new NotImplementedException("Yo call CreatePackage instead for now.");
        } 
        /// <summary>
        /// Create a manifest.
        /// </summary>
        /// <param name="archive"></param>
        private void CreateManifest(ZipArchive archive)
        {
            ///Manifest file is zip root / "lucid-manifest"    
            ///See Lucid/Resouce/ManifestFormat.txt to see how it's formatted.
            var manifestEntry = archive.CreateEntry("lucid-manifest");
            using (var manifest = manifestEntry.Open())
            using (var w = new StreamWriter(manifest))
            {
                ManifestBuilder writer = new ManifestBuilder();

                foreach (var r in resourceTree.GetResources())
                    writer.Add(r.GetResourcePath(), r.Resource);

                w.Write(writer.GetManifest()); //Write the whole manifest in one chunk.
            }
        }

        /// <summary>
        /// Write a file to the zip file.
        /// </summary>
        /// <param name="archive">zip archive to write file to</param>
        /// <param name="resource">resource to write to zip file</param>
        private void CreateFile(ZipArchive archive, ResourceNode resource)
        {
            ///Create the entry in the archive.
            var entry = archive.CreateEntry(resource.GetResourcePath());
            entry.LastWriteTime = resource.Resource.LastModified;

            using (var zipStream = entry.Open())
            {
                using (var fileStream = File.Open(resource.Resource.FilePath, FileMode.Open))
                {
                    fileStream.CopyTo(zipStream);
                }
            }
        }
    }
}
