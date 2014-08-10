using Swagger.Codegen.CodegenProcessors.CSharp;

namespace Swagger.Codegen.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var codeGenerator = new Codegenerator();
            codeGenerator.Process(
                new CodegenSettings
                {
                    ApiName = "PetStore",
                    Url = "http://petstore.swagger.wordnik.com/api/api-docs",
                    Processor = new CSharpProcessor(),
                    OutputPath = ".\\out",
                    Namespace = "MyApplication"
                }
            );
        }
    }
}