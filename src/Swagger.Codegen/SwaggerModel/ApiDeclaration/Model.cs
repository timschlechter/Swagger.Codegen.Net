using System.Collections.Generic;
namespace Swagger.Codegen.SwaggerModel.ApiDeclaration
{
    public class Model
    {
        public string id { get; set; }

        public string[] required { get; set; }

        public IDictionary<string, ModelProperty> properties { get; set; }
    }
}