using Swagger.Codegen.Models;
using Swagger.Codegen.SwaggerModel.ApiDeclaration;

namespace Swagger.Codegen.Processors.CSharp
{
    public partial class EndpointTemplate
    {
        public EndpointModel Endpoint { get; set; }

        public CodegenSettings Settings { get; set; }

        public static string GetTypeString(PropertyModel property)
        {
            return GetTypeString(property.Type, property.TypeIsList, property.IsRequired);
        }

        private static string GetTypeString(TypeModel type, bool typeIsList, bool isRequired = false)
        {
            if (type == null)
            {
                return "void";
            }

            var typeName = string.Format(
                "{0}{1}",
                type.IsPrimitive ? type.Name : type.Name.ToPascalCase(),
                type.CanBeNullable && !typeIsList && !isRequired ? "?" : ""
            );

            return typeIsList
                        ? string.Format("IList<{0}>", typeName)
                        : typeName;
        }

        public static string GetResponseTypeString(RouteModel route)
        {
            return GetTypeString(route.ResponseType, route.ResponseIsList);
        }

    }
}