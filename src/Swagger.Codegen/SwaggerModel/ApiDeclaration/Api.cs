namespace Swagger.Codegen.SwaggerModel.ApiDeclaration
{
    public class Api
    {
        public string description { get; set; }

        public Operation[] operations { get; set; }

        public string path { get; set; }
    }
}