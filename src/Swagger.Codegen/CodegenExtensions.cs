using Swagger.Codegen.SwaggerModel.ApiDeclaration;
using System.Text;

namespace Swagger.Codegen
{
    internal static class CodegenExtensions
    {
        public static string GetResourceName(this ApiDeclaration apiDeclaration)
        {
            return apiDeclaration.resourcePath.Replace("/", " ").ToPascalCase().Trim();
        }

        public static string ToPascalCase(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return val;
            }

            var sb = new StringBuilder();
            var nextToUpper = true;
            foreach (var c in val.Trim())
            {
                if (char.IsLetter(c))
                {
                    sb.Append(nextToUpper ? char.ToUpper(c) : c);
                    nextToUpper = false;
                }
                else
                {
                    nextToUpper = true;
                }
            }

            return sb.ToString();
        }
    }
}