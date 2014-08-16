using Swagger.Codegen.CodegenProcessors.CSharp;
using System.IO;

namespace Swagger.Codegen.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            
            if (CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
            {
                if (!options.OutputPath.EndsWith(".cs"))
                {
                    options.OutputPath = Path.Combine(options.OutputPath, options.ApiName + "Client.cs");
                }

                using (var fs = new FileStream(options.OutputPath, FileMode.OpenOrCreate))
                {
                    var codeGenerator = new Codegenerator();
                    codeGenerator.Process(
                        new CodegenSettings
                        {
                            ApiName = options.ApiName,
                            ApiUrl = options.Url,
                            Processor = new CSharpProcessor(),
                            Namespace = options.Namespace
                        },
                        fs
                    );
                }
            }

           
        }
    }
}