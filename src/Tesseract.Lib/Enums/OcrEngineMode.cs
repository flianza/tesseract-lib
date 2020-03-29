namespace Tesseract.Lib
{
    public enum OcrEngineMode
    {
        /// <summary>
        /// Original Tesseract only.
        /// </summary>
        TesseractOnly = 0,

        /// <summary>
        /// Neural nets LSTM only.
        /// </summary>
        LstmOnly = 1,

        /// <summary>
        /// Tesseract + LSTM.
        /// </summary>
        TesseractLstmCombined = 2,

        /// <summary>
        /// Default, based on what is available.
        /// </summary>
        Default = 3
    }
}
