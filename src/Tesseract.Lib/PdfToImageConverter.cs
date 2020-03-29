using Spire.Pdf;
using System;
using System.Drawing;

namespace Tesseract.Lib
{
    public class PdfToImageConverter : IPdfToBImageConverter
    {
        public string Convert(byte[] pdfData)
        {
            var pdf = new PdfDocument(pdfData);
            var img = pdf.SaveAsImage(0, 150, 150);
            var imgFilePath = $"tess_{Guid.NewGuid().ToString("N")}.png";
            img.Save(imgFilePath);
            return imgFilePath;
        }
    }
}