using System;
using System.Collections.Generic;
using System.IO;

namespace Tesseract.Lib
{
    public class Tesseract : ITesseract
    {
        private readonly ITesseractEngine tessaractEngine;
        private readonly IPdfToBImageConverter pdfToBitmapConverter;
        public Tesseract(ITesseractEngine tessaractEngine, IPdfToBImageConverter pdfToBitmapConverter)
        {
            this.tessaractEngine = tessaractEngine;
            this.pdfToBitmapConverter = pdfToBitmapConverter;
        }

        public string PdfToText(byte[] pdfData, TesseractOptions options)
        {
            string imageFilePath = string.Empty;
            try
            {
                imageFilePath = this.pdfToBitmapConverter.Convert(pdfData);
                return this.FileToText(imageFilePath, options);
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(imageFilePath) && File.Exists(imageFilePath))
                {
                    File.Delete(imageFilePath);
                }
            }
        }

        public string FileToText(string inputFilePath, TesseractOptions options)
        {
            options.ConfigFiles = new List<ConfigFile> { ConfigFile.OutputTxt };

            ProcessResult processResult;
            try
            {
                processResult = this.tessaractEngine.Process(inputFilePath, options);
            }
            catch (Exception ex)
            {
                throw new TesseractException("Fail to call tesseract", ex);
            }

            if (processResult.ExitCode != 0)
            {
                throw new InvalidOperationException(processResult.Error);
            }

            return processResult.Output;
        }
    }
}
