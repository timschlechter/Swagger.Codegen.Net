using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Swagger.Codegen
{
    public interface ICodegenProcessor
    {
		string Name { get; }

        void Process(CodegenSettings settings, Stream stream);
    }
}
