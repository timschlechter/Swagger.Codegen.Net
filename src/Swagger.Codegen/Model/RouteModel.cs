namespace Swagger.Codegen.Model
{
    public class RouteModel
    {
        public string Description { get; set; }

        public HttpMethod Method { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string Remarks { get; set; }

        public TypeModel Type { get; set; }
    }
}