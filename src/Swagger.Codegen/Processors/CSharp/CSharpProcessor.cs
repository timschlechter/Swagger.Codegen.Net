using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Swagger.Codegen.Processors.CSharp.Templates;
using System.Text;

namespace Swagger.Codegen.CodegenProcessors.CSharp
{
	public class CSharpProcessor : ICodegenProcessor
	{
		public string Name
		{
			get { return "C#"; }
		}

        public void Process(CodegenSettings settings, Stream stream)
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

			// Indent snippets when a namespace is set
			if (!String.IsNullOrEmpty(settings.Namespace))
			{
				snippets = snippets.Select(s => "    " + s.Replace(Environment.NewLine, Environment.NewLine + "    ")).ToList();
			}

			var contents = new Output
			{
				Settings = settings,
				Snippets = snippets
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