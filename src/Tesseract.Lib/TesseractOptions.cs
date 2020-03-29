using System.Collections.Generic;

namespace Tesseract.Lib
{
    public class TesseractOptions
    {
        public long? DotPerInch { get; set; }
        public PageSegmentationMode? PageSegmentationMode { get; set; }
        public OcrEngineMode? OcrEngineMode { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<KeyValuePair<string, string>> ConfigVars { get; set; }
        internal string OutputBasenameFilePath { get; set; } = "stdout";
        internal IEnumerable<ConfigFile> ConfigFiles { get; set; }
    }
}
