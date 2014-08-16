namespace Swagger.Codegen
{
    public class CodegenSettings
    {
        public string ApiName { get; set; }

        public string ApiUrl { get; set; }

        public string Namespace { get; set; }

        public ICodegenProcessor Processor { get; set; }
    }
}