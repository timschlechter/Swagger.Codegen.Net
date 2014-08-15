using Nancy;
using Nancy.ModelBinding;
using Swagger.Codegen.CodegenProcessors.CSharp;
using Swagger.Codegen.Web.Api.Models;

namespace Swagger.Codegen.Web.Api
{
    public class ProcessorsModule : NancyModule
    {
        public ProcessorsModule()
            : base("/api/processors")
        {
            Post["/jobs"] = _ => PostProcessorJob(this.Bind<ProcessorJobModel>());
        }

        private static dynamic PostProcessorJob(ProcessorJobModel job)
        {
            var response = new Response();
            var filename = (string.IsNullOrEmpty(job.Options.ApiName) ? "" : job.Options.ApiName) + "Client.cs";

            response.Headers.Add("Content-Disposition", "attachment; filename=" + filename.ToValidFilename());
            response.Headers.Add("x-filename", filename.ToValidFilename());
            response.ContentType = "text/plain";
            response.Contents = stream =>
            {
                var codeGenerator = new Codegenerator();
                codeGenerator.Process(
                    new CodegenSettings
                    {
                        ApiUrl = job.Options.ApiUrl,
                        ApiName = job.Options.ApiName,
                        Processor = new CSharpProcessor()
                    },
                    stream
                );
            };

            return response;
        }
    }
}