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

        public static string ToTitleCase(this string val)
        {
            return ci.TextInfo.ToTitleCase(val); 
        }

        public static string GetResourceName(this ApiDeclaration apiDeclaration)
        {
            return apiDeclaration.resourcePath.Replace("/", " ").ToTitleCase().Trim();
        }      
    }
}
