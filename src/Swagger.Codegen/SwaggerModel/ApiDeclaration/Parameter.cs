namespace Swagger.Codegen.SwaggerModel.ApiDeclaration
{
    public class Parameter : DataType
    {
        public bool allowMultiple { get; set; }

        public string description { get; set; }

        public string name { get; set; }

        public string paramType { get; set; }

        public bool required { get; set; }
    }
}