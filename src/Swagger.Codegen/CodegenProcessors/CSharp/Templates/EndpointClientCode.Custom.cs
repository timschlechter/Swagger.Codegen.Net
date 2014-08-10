using Swagger.Codegen.SwaggerModel.ApiDeclaration;

namespace Swagger.Codegen.CodegenProcessors.CSharp.Templates
{
    public partial class EndpointClientCode
    {
        public ApiDeclaration ApiDeclaration { get; set; }

        public CodegenSettings Settings { get; set; }
    }
}