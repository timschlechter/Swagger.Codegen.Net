using System.Collections.Generic;

namespace Swagger.Codegen.Model
{
    public class ApiModel
    {
        public string BaseUrl { get; set; }

        public string Contact { get; set; }

        public string Description { get; set; }

        public IList<EndpointModel> Endpoints { get; set; }

        public string License { get; set; }

        public string LicenseUrl { get; set; }

        public string Name { get; set; }

        public string SwaggerVersion { get; set; }

        public string TermsOfServiceUrl { get; set; }

        public string Title { get; set; }

        public string Version { get; set; }
    }
}