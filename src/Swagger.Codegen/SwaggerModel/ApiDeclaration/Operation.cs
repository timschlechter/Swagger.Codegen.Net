namespace Swagger.Codegen.SwaggerModel.ApiDeclaration
{
    public class Operation : DataType
    {
        public Authorizations authorizations { get; set; }

        public string[] consumes { get; set; }

        public string deprecated { get; set; }

        public string method { get; set; }

        public string nickname { get; set; }

        public string notes { get; set; }

        public Parameter[] parameters { get; set; }

        public string[] produces { get; set; }

        public Responsemessage[] responseMessages { get; set; }

        public string summary { get; set; }

        public string type { get; set; }
    }
}