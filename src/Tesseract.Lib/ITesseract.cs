namespace Tesseract.Lib
{
    public interface ITesseract
    {
        string FileToText(string inputFilePath, TesseractOptions options);
        string PdfToText(byte[] pdfData, TesseractOptions options);
    }
}
