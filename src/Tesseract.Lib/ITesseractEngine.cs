using System.Collections.Generic;

namespace Tesseract.Lib
{
    public interface ITesseractEngine
    {
        ProcessResult Process(string inputFilePath, TesseractOptions options);
    }
}
