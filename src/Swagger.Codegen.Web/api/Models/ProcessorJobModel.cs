using Newtonsoft.Json;

namespace Swagger.Codegen.Web.Api.Models
{
    public class ProcessorJobModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("options")]
        public ProcessorJobOptionsModel Options { get; set; }
    }
}