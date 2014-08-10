namespace Swagger.Codegen.SwaggerModel.ResourceListing
{
    public class ResourceListing
    {
        public Api[] apis { get; set; }

        public string apiVersion { get; set; }

        public Authorizations authorizations { get; set; }

        public Info info { get; set; }

        public string swaggerVersion { get; set; }
    }
}