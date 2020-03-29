using System.Collections.Generic;

namespace Tesseract.Lib
{
    public interface IProcessRunner
    {
        ProcessResult RunProcess(string command, IEnumerable<string> arguments = null, int? timeout = null, IEnumerable<KeyValuePair<string, string>> environmentVariables = null);
    }
}
