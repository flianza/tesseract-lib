namespace Tesseract.Lib
{
    public interface IPdfToBImageConverter
    {
        string Convert(byte[] pdfData);
    }
}
