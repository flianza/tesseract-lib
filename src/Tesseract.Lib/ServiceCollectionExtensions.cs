using Microsoft.Extensions.DependencyInjection;

namespace Tesseract.Lib
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTesseract(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IResourcesManager, ResourcesManager>();
            serviceCollection.AddTransient<IProcessRunner, ProcessRunner>();
            serviceCollection.AddTransient<ITesseractEngine, TesseractEngine>();
            serviceCollection.AddTransient<ITesseract, Tesseract>();
            serviceCollection.AddTransient<IPdfToBImageConverter, PdfToImageConverter>();
        }
    }
}
