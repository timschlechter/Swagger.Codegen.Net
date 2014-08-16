using Swagger.Codegen.Models;
using System.IO;

namespace Swagger.Codegen
{
    public interface ICodegenProcessor
    {
        string Name { get; }

        void Process(ApiModel model, CodegenSettings settings, Stream stream);
    }
}