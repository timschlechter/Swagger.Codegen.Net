using Swagger.Codegen.CodegenProcessors.CSharp.Templates;
using System.IO;
using System.Threading.Tasks;

namespace Swagger.Codegen.CodegenProcessors.CSharp
{
    public class CSharpProcessor : ICodegenProcessor
    {
        public void Process(CodegenSettings settings)
        {
            var endpointsPath = Path.Combine(settings.OutputPath, "Endpoints");
            var modelsPath = Path.Combine(settings.OutputPath, "Models");

            CreateIfNotExists(settings.OutputPath);
            CreateIfNotExists(endpointsPath);
            CreateIfNotExists(modelsPath);

            // {ApiName}Client.cs
            File.WriteAllText(
                path: Path.Combine(settings.OutputPath, settings.ApiName + "Client.cs"),
                contents: new ClientCode
                {
                    Settings = settings
                }.TransformText()
            );

            // Endpoints/EndClientBase.cs
            File.WriteAllText(
                path: Path.Combine(endpointsPath, "EndpointClientBase.cs"),
                contents: new EndpointClientBaseCode
                {
                    Settings = settings
                }.TransformText()
            );

            // Endpoints/{ResourceName}Client.cs
            Parallel.ForEach(settings.ApiDeclarations, apiDeclaration =>
            {
                File.WriteAllText(
                    path: Path.Combine(endpointsPath, apiDeclaration.GetResourceName() + "Client.cs"),
                    contents: new EndpointClientCode
                    {
                        Settings = settings,
                        ApiDeclaration = apiDeclaration
                    }.TransformText()
                );
            });
        }

        private static void CreateIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}