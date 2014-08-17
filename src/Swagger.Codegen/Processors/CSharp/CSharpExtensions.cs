using Swagger.Codegen.Models;
using System;
using System.Linq;

namespace Swagger.Codegen.Processors.CSharp
{
    public static class CSharpExtensions
    {
        public static string GetResponseTypeName(this RouteModel route)
        {
            if (route.ResponseType == null)
            {
                return "void";
            }

            var typeName = route.ResponseType.Name.ToPascalCase();

            return route.ResponseIsList
                        ? string.Format("IList<{0}>", typeName)
                        : typeName;
        }

        public static string GetResponseTypeName(this PropertyModel property)
        {
            var typeName = property.Type.Name.ToPascalCase();

            return property.TypeIsList
                        ? string.Format("IList<{0}>", typeName)
                        : typeName;
        }

        public static string NormalizeLineEndings(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return null;
            }

            return val.Replace("\r\n", Environment.NewLine)
                      .Replace("\n", Environment.NewLine);
        }

        public static string ToCSharpComment(this string comment, int? indent = null)
        {
            if (string.IsNullOrEmpty(comment))
            {
                return null;
            }

            return "/// " + comment.NormalizeLineEndings()
                                   .Replace(
                                        Environment.NewLine,
                                        Environment.NewLine + string.Join("", Enumerable.Repeat(" ", indent.GetValueOrDefault())) + "/// ");
        }
    }
}