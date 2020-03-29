using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tesseract.Lib
{
    internal class TesseractEngine : ITesseractEngine
    {
        private readonly IResourcesManager resourcesManager;
        private readonly IProcessRunner processRunner;

        private const string TesseractData = "tessdata";

        public TesseractEngine(IResourcesManager resourcesManager, IProcessRunner processRunner)
        {
            this.resourcesManager = resourcesManager;
            this.processRunner = processRunner;
        }

        public ProcessResult Process(string inputFilePath, TesseractOptions options)
        {
            if (!File.Exists(inputFilePath))
            {
                throw new ArgumentException($"Input file '{inputFilePath}' does not exit.");
            }

            if (!this.resourcesManager.TryGetDirectory(TesseractData, out var tesseractData))
            {
                throw new InvalidOperationException($"'{TesseractData}' directory not found.");
            }

            var cmd = "tesseract";
            var args = this.BuildArgs(inputFilePath, options);
            var environmentVariables = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("TESSDATA_PREFIX", tesseractData)
            };

            return this.processRunner.RunProcess(cmd, args, environmentVariables: environmentVariables);
        }

        private List<string> BuildArgs(string inputFilePath, TesseractOptions options)
        {
            var args = new List<string> { $"\"{inputFilePath}\"" };

            if (options != null)
            {
                if (options.OutputBasenameFilePath != null)
                    args.Add(options.OutputBasenameFilePath);

                if (options.DotPerInch != null)
                    args.Add($"--dpi {options.DotPerInch}");

                if (options.PageSegmentationMode != null)
                    args.Add($"--psm {(int)options.PageSegmentationMode}");

                if (options.OcrEngineMode != null)
                    args.Add($"--oem {(int)options.OcrEngineMode}");

                if (options.Languages != null)
                    args.Add("-l " + string.Join("+", options.Languages.Select(l => l.ToName())));

                if (options.ConfigVars != null)
                    args.Add(string.Join(" ", options.ConfigVars.Select(kv => $"-c {kv.Key}={kv.Value}")));

                if (options.ConfigFiles != null)
                    args.Add(string.Join(" ", options.ConfigFiles.Select(cf => cf.ToName())));
            }

            return args;
        }
    }
}
