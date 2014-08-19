using Swagger.Codegen.Models;
using System;
using System.Linq;

namespace Swagger.Codegen.Processors.CSharp
{
    public static class CSharpExtensions
    {
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