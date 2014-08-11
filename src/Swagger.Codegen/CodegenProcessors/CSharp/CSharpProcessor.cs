using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Swagger.Codegen.CodegenProcessors.CSharp.Templates;

namespace Swagger.Codegen.CodegenProcessors.CSharp
{
    public class CSharpProcessor : ICodegenProcessor
    {
        public void Process(CodegenSettings settings)
        {
            var snippets = new List<string>();

            // {ApiName}Client
            snippets.Add(new ClientCode { Settings = settings }.TransformText());

            // EndpointClientBase
            snippets.Add(new EndpointClientBaseCode { Settings = settings }.TransformText());

            // {ResourceName}Client
            Parallel.ForEach(settings.ApiDeclarations, apiDeclaration =>
            {
                snippets.Add(new EndpointClientCode { Settings = settings, ApiDeclaration = apiDeclaration }.TransformText());
            });

            if (!Directory.Exists(settings.OutputPath))
            {
                Directory.CreateDirectory(settings.OutputPath);
            }

            File.WriteAllText(
                path: Path.Combine(settings.OutputPath, settings.ApiName + "Client.cs"),
                contents: new Output
                {
                    Settings = settings,
                    Snippets = snippets.Select(s => "    " + s.Replace(Environment.NewLine, Environment.NewLine + "    ")).ToList()
                }.TransformText()
            );
        }
    }
}