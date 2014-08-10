namespace Swagger.Codegen.SwaggerModel.ApiDeclaration
{
    public class ApiDeclaration
    {
        public Api[] apis { get; set; }

        public string apiVersion { get; set; }

        public string basePath { get; set; }

        public Models models { get; set; }

        public string[] produces { get; set; }

        public string resourcePath { get; set; }

        public string swaggerVersion { get; set; }
    }
}