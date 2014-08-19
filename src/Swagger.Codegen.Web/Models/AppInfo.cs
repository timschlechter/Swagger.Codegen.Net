using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Swagger.Codegen.Web.Models
{
    public class AppInfo
    {
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}