using System.Collections.Generic;
using CommandLine;

namespace Swagger.Codegen.Console
{
    public class CommandLineOptions
    {
        [Option('a', "apiname", Required = true, HelpText = "The name of the API")]
        public string ApiName { get; set; }

        [Option('u', "url", Required = true, HelpText = "The url of the API which serves the resource listing")]
        public string Url { get; set; }

        [Option('n', "namespace", HelpText = "Specifies the namespace for the generated proxy or template. The default namespace is the global namespace.")]
        public string Namespace { get; set; }

        [Option('o', "out", DefaultValue=".", HelpText = "Specifies the file (or directory) in which to save the generated proxy code. You can also specify a directory in which to create this file. The tool derives the default file name from the API name.")]
        public string OutputPath { get; set; }

    }
}