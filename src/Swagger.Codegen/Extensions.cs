using Swagger.Codegen.SwaggerModel.ApiDeclaration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Swagger.Codegen
{
    internal static class Extensions
    {
        static CultureInfo ci = new CultureInfo("en-US", false);

        public static string ToPascalCase(this string val)
        {
			if (string.IsNullOrEmpty(val))
			{
				return val;
			}

			var sb = new StringBuilder();
			foreach (var c in val)
			{
				sb.Append(c);
			}

			return sb.ToString();
        }

        public static string GetResourceName(this ApiDeclaration apiDeclaration)
        {
            return apiDeclaration.resourcePath.Replace("/", " ").ToPascalCase().Trim();
        }      
    }
}
