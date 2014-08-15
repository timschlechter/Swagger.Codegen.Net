using Newtonsoft.Json;

namespace Swagger.Codegen.Web.Api.Models
{
    public class ProcessorJobOptionsModel
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("apiName", Required = Required.Always)]
        public string ApiName { get; set; }

        [JsonProperty("apiUrl", Required = Required.Always)]
        public string ApiUrl { get; set; }
    }
}