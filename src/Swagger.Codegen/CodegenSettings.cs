using Swagger.Codegen.SwaggerModel.ApiDeclaration;
using Swagger.Codegen.SwaggerModel.ResourceListing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.Codegen
{
    public class CodegenSettings
    {
        public string ApiName { get; set; }

        public string Url { get; set; }

        public ICodegenProcessor Processor { get; set; }

        public string OutputPath { get; set; }

        public string Namespace { get; set; }

        internal IList<ApiDeclaration> ApiDeclarations { get; set; }

        internal ResourceListing ResourceListing { get; set; }
    }
}
