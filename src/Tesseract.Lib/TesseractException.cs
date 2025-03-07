﻿using System;

namespace Tesseract.Lib
{
    public class TesseractException : Exception
    {
        public TesseractException(string message) : base(message) { }

        public TesseractException(string message, Exception innerException) : base(message, innerException) { }
    }
}
