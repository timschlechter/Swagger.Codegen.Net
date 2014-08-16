using Swagger.Codegen.Model;
using Swagger.Codegen.SwaggerModel.ApiDeclaration;

namespace Swagger.Codegen.Processors.CSharp
{
    public partial class EndpointTemplate
    {
        public EndpointModel Endpoint { get; set; }

        public CodegenSettings Settings { get; set; }
    }
}