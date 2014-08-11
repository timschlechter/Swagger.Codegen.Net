using Swagger.Codegen.CodegenProcessors.CSharp;

namespace Swagger.Codegen.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            
            if (CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
            {
                var codeGenerator = new Codegenerator();
                codeGenerator.Process(
                    new CodegenSettings
                    {
                        ApiName = options.ApiName,
                        Url = options.Url,
                        Processor = new CSharpProcessor(),
                        OutputPath = options.OutputPath,
                        Namespace = options.Namespace
                    }
                );
            }

           
        }
    }
}