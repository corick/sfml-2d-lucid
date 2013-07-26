using System;
using System.IO;
using System.IO.Compression;

namespace Lucid.Framework.Resource //TODO: Separate this into another dll.
{
    public class ZipPack //FIXME: I should be internal, and we should expose an interface instead!
        : IDisposable
    {
        private ZipArchive packFile;
        private PackManifest manifest;

        public ZipPack(string filePath)
        {
            FileStream zipFile = File.OpenRead(filePath);
            packFile = new ZipArchive(zipFile, ZipArchiveMode.Read, false);

            manifest = new PackManifest();
            using (var m = packFile.GetEntry("lucid-manifest").Open())
            {
                manifest.ReadManifest(m);
                m.Close();
            }
        }

        /// <summary>
        /// Gets the resource handle for a packed file.
        /// Remember to close me!
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ResourceHandle GetFile(string path)
        {
            ZipArchiveEntry zipEntry = this.packFile.GetEntry(path);
            Type fileType = manifest.GetFileType(path);
            ResourceHandle handle = new ResourceHandle(zipEntry, fileType);
            return handle;
        }

        public void Dispose()
        {
            if (packFile != null)
                packFile.Dispose();
        }
    }
}
