namespace Tesseract.Lib
{
    public enum PageSegmentationMode
    {
        /// <summary>
        /// Orientation and script detection (OSD) only.
        /// </summary>
        OsdOnly = 0,

        /// <summary>
        /// Automatic page segmentation with OSD.
        /// </summary>
        AutoOsd = 1,

        /// <summary>
        /// Automatic page segmentation, but no OSD, or OCR. (not implemented)
        /// </summary>
        AutoOnly = 2,

        /// <summary>
        /// Fully automatic page segmentation, but no OSD. (Default)
        /// </summary>
        Auto = 3,

        /// <summary>
        /// Assume a single column of text of variable sizes.
        /// </summary>
        SingleColumn = 4,

        /// <summary>
        /// Assume a single uniform block of vertically aligned text.
        /// </summary>
        SingleBlockVertText = 5,

        /// <summary>
        /// Assume a single uniform block of text.
        /// </summary>
        SingleBlock = 6,

        /// <summary>
        /// Treat the image as a single text line.
        /// </summary>
        SingleLine = 7,

        /// <summary>
        /// Treat the image as a single word.
        /// </summary>
        SingleWord = 8,

        /// <summary>
        /// Treat the image as a single word in a circle.
        /// </summary>
        CircleWord = 9,

        /// <summary>
        /// Treat the image as a single character.
        /// </summary>
        SingleChar = 10,

        /// <summary>
        /// Sparse text. Find as much text as possible in no particular order.
        /// </summary>
        SparseText = 11,

        /// <summary>
        /// Sparse text with OSD.
        /// </summary>
        SparseTextOsd = 12,

        /// <summary>
        /// Raw line. Treat the image as a single text line
        /// </summary>
        RawLine = 13
    }
}
