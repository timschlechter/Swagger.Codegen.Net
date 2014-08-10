using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swagger.Codegen
{
    public interface ICodegenProcessor
    {
        void Process(CodegenSettings settings);
    }
}
