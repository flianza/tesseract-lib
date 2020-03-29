using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace Tesseract.Lib
{
    internal class ResourcesManager : IResourcesManager
    {
        private const string ResourceFile = "Resources.zip";
        private readonly string assemblyDirectory;

        public ResourcesManager()
        {
            var assembly = Assembly.GetAssembly(typeof(ResourcesManager));
            this.assemblyDirectory = Path.GetDirectoryName(assembly.Location);

            try
            {
                using var stream = assembly.GetManifestResourceStream(ResourceFile);
                this.Extract(stream, this.assemblyDirectory);
            }
            catch (FileNotFoundException ex)
            {
                throw new TesseractException("Resources not found", ex);
            }
        }

        private void Extract(Stream stream, string extractPath)
        {
            using var archive = new ZipArchive(stream);
            foreach (var entry in archive.Entries)
            {
                var destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));
                var destinationDir = Path.GetDirectoryName(destinationPath);
                if (!Directory.Exists(destinationDir))
                {
                    Directory.CreateDirectory(destinationDir);
                }

                entry.ExtractToFile(destinationPath, overwrite: true);
            }
        }

        public bool TryGetDirectory(string name, out string path)
        {
            path = Path.Combine(this.assemblyDirectory, name);

            if (!Directory.Exists(path))
            {
                path = null;
                return false;
            }

            return true;
        }
    }
}
