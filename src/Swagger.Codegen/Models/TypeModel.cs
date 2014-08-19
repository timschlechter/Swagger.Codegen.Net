using System.Collections.Generic;

namespace Swagger.Codegen.Models
{
    public class TypeModel
    {
        public bool IsPrimitive { get; set; }

        public string Name { get; set; }

        public IList<PropertyModel> Properties { get; set; }

        public bool CanBeNullable { get; set; }
    }
}