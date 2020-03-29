using System;
using System.IO;

namespace Tesseract.Lib
{
    public class PdfToImageConverter : IPdfToBImageConverter
    {
        private readonly IProcessRunner processRunner;
        public PdfToImageConverter(IProcessRunner processRunner)
        {
            this.processRunner = processRunner;
        }

        public string Convert(byte[] pdfData)
        {
            var pdfFilePath = $"tess_{Guid.NewGuid().ToString("N")}.pdf";
            var imageFilePath = $"tess_{Guid.NewGuid().ToString("N")}.png";
            File.WriteAllBytes(pdfFilePath, pdfData);

            try
            {
                var processResult = this.processRunner.RunProcess("convert", new[] { "-density 300", $"{pdfFilePath}[0]", imageFilePath });
                //var processResult = this.processRunner.RunProcess("gs", new[] { "-sDEVICE=png16m", $"-o {imageFilePath}", "-r300", $"-c \"30000000 setvmthreshold\"", pdfFilePath });

                if (processResult.ExitCode != 0)
                {
                    throw new InvalidOperationException(processResult.Error);
                }

                if (!File.Exists(imageFilePath))
                {
                    imageFilePath = imageFilePath.Replace(".png", "-0.png");
                }
            }
            finally
            {
                if (File.Exists(pdfFilePath))
                {
                    File.Delete(pdfFilePath);
                }
            }
            
            return imageFilePath;
        }
    }
}