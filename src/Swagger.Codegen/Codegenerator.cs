using Swagger.Codegen.SwaggerModel.ApiDeclaration;
using Swagger.Codegen.SwaggerModel.ResourceListing;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Swagger.Codegen
{
    public class Codegenerator
    {
        public void Process(CodegenSettings settings)
        {
            settings.ResourceListing = Get<ResourceListing>(settings.Url);
            settings.ApiDeclarations = new List<ApiDeclaration>();

            Parallel.ForEach(settings.ResourceListing.apis, api =>
            {
                settings.ApiDeclarations.Add(Get<ApiDeclaration>(settings.Url + api.path));
            });

            settings.Processor.Process(settings);
        }

        private static T Get<T>(string url)
        {
            var req = HttpWebRequest.Create(url);
            req.Method = "GET";
            var response = req.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                var content = sr.ReadToEnd();

                return SimpleJson.DeserializeObject<T>(content);
            };
        }
    }
}