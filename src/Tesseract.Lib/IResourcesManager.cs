namespace Tesseract.Lib
{
    internal interface IResourcesManager
    {
        bool TryGetDirectory(string name, out string path);
    }
}
