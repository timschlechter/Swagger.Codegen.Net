namespace Swagger.Codegen.SwaggerModel.ApiDeclaration
{
    public class DataType
    {
        public string[] _enum { get; set; }

        public string _ref { get; set; }

        public object defaultValue { get; set; }

        public string format { get; set; }

        public Items items { get; set; }

        public string maximum { get; set; }

        public string minimum { get; set; }

        public string type { get; set; }

        public bool uniqueItems { get; set; }
    }
}