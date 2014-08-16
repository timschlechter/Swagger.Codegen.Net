using Swagger.Codegen.Model;
using System.Collections.Generic;

namespace Swagger.Codegen.Processors.CSharp
{
    public partial class WrapperTemplate
    {
        public ApiModel Api { get; set; }

        public string Snippet { get; set; }

        public CodegenSettings Settings { get; set; }
    }
}