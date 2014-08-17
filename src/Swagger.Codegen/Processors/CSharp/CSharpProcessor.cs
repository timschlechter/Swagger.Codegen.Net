using Swagger.Codegen.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Swagger.Codegen.Processors.CSharp
{
    public class CSharpProcessor : ICodegenProcessor
    {
        public string Name
        {
            get { return "C#"; }
        }

        public void Process(ApiModel api, CodegenSettings settings, Stream stream)
        {
            var snippets = new List<string>();

            // Api Client
            snippets.Add(new ClientTemplate { Api = api, Settings = settings }.TransformText());

            // Endpoint Clients
            foreach (var endpoint in api.Endpoints)
            {
                snippets.Add(new EndpointTemplate { Endpoint = endpoint, Settings = settings }.TransformText());
            };

            // Indent snippets when a namespace is set
            if (!String.IsNullOrEmpty(settings.Namespace))
            {
                snippets = snippets.Select(s => "    " + s.Replace(Environment.NewLine, Environment.NewLine + "    ")).ToList();
            }

            var contents = new WrapperTemplate
            {
                Api = api,
                Snippet = string.Join(Environment.NewLine + Environment.NewLine, snippets),
                Settings = settings
            }.TransformText();

            using (var sr = new StreamWriter(stream, Encoding.UTF8))
            {
                sr.Write(contents);
            }
        }

        private static void WriteToFile(string path, string contents)
        {
            var outputFolder = Path.GetDirectoryName(path);
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            File.WriteAllText(
                path: path,
                contents: contents
            );
        }
    }
}