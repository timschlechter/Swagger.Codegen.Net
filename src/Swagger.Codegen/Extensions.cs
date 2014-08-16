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

        public static string GetResourceName(this ApiDeclaration apiDeclaration)
        {
            return apiDeclaration.resourcePath.Replace("/", " ").ToPascalCase().Trim();
        }      
    }
}
