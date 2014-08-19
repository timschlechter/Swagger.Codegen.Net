using Swagger.Codegen.Models;
using Swagger.Codegen.SwaggerModel.ApiDeclaration;
using Swagger.Codegen.SwaggerModel.ResourceListing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Swagger.Codegen
{
    public class Codegenerator
    {
        private static Dictionary<string, TypeModel> _primitives = new Dictionary<string, TypeModel>
        {
            { "int32", new TypeModel { Name = "integer" } },
            { "int64", new TypeModel { Name = "long" } },
            { "float", new TypeModel { Name = "float" } },
            { "double", new TypeModel { Name = "double" } },
            { "string", new TypeModel { Name = "string" } },
            { "byte", new TypeModel { Name = "byte" } },
            { "boolean", new TypeModel { Name = "bool" } },
            { "date", new TypeModel { Name = "DateTime" } },
            { "date-time", new TypeModel { Name = "DateTime" } }
        };

        public void Process(CodegenSettings settings, Stream stream)
        {
            var model = RetrieveCodegenModel(settings.ApiUrl, settings.ApiName);
            settings.Processor.Process(model, settings, stream);
        }

        private static EndpointModel CreateEndpoint(ApiDeclaration apiDeclaration, SwaggerModel.ResourceListing.Api resourceListingApi)
        {
            var types = apiDeclaration.models.Values.Select(model => new TypeModel
            {
                Name = model.id,
            }).ToList();

            types.ForEach((type) =>
            {
                type.Properties = apiDeclaration.models[type.Name].properties.Select(kvp =>
                {
                    var name = kvp.Key;
                    var property = kvp.Value;
                    var typeIsList = property.type == "array";
                    return new PropertyModel
                    {
                        Name = name,
                        Description = property.description,
                        TypeIsList = typeIsList,
                        Type = typeIsList
                                    ? types.FirstOrDefault(t => t.Name == property.items._ref) ?? GetPrimitiveType(property.items.type, property.items.format)
                                    : types.FirstOrDefault(t => t.Name == property._ref) ?? GetPrimitiveType(property.type, property.format)
                    };
                }).ToList();
            });

            return new EndpointModel
            {
                Description = resourceListingApi.description,
                Name = apiDeclaration.resourcePath.ToPascalCase(),
                BasePath = apiDeclaration.basePath,
                ResourcePath = apiDeclaration.resourcePath,
                Routes = apiDeclaration.apis.SelectMany(
                    api => api.operations.Select(
                        o => CreateRouteModel(o, api, types)
                    )
                ).OrderBy(r => r.Name).ToList(),
                Types = types
            };
        }

        private static HttpMethod CreateHttpMethod(string val)
        {
            HttpMethod result;

            Enum.TryParse<HttpMethod>(val, out result);

            return result;
        }

        private static RouteModel CreateRouteModel(Operation o, Swagger.Codegen.SwaggerModel.ApiDeclaration.Api api, IEnumerable<TypeModel> knownTypes)
        {
            var responseIsList = o.type == "array";
            return new RouteModel
            {
                Method = CreateHttpMethod(o.method),
                Name = o.nickname,
                Path = api.path,
                ResponseIsList = responseIsList,
                ResponseType = responseIsList
                                    ? knownTypes.FirstOrDefault(t => t.Name == o.items._ref) ?? GetPrimitiveType(o.items.type, o.items.format)
                                    : knownTypes.FirstOrDefault(t => t.Name == o.type) ?? GetPrimitiveType(o.type, o.format),
                Description = o.summary,
                Remarks = o.notes
            };
        }

        private static T Get<T>(string url)
        {
            var req = HttpWebRequest.Create(url);
            req.Method = "GET";
            var response = req.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                var content = sr.ReadToEnd();
                content = content.Replace("\"$ref\"", "\"_ref\"");
                return SimpleJson.DeserializeObject<T>(content);
            };
        }

        private static TypeModel GetPrimitiveType(string type, string format)
        {
            var key = format ?? type;
            return _primitives.Where(kvp => kvp.Key == key)
                              .Select(kvp => kvp.Value)
                              .FirstOrDefault();
        }

        private static ApiModel RetrieveCodegenModel(string apiUrl, string apiName)
        {
            var resourceListing = Get<ResourceListing>(apiUrl);
            var apiDeclarations = new List<ApiDeclaration>();

            Parallel.ForEach(resourceListing.apis, api =>
            {
                apiDeclarations.Add(Get<ApiDeclaration>(apiUrl + api.path));
            });

            return new ApiModel
            {
                Name = apiName,
                BaseUrl = apiUrl,
                Version = resourceListing.apiVersion,
                Contact = resourceListing.info.contact,
                Description = resourceListing.info.description,
                Endpoints = apiDeclarations.Select(apiDeclaration => CreateEndpoint(
                    apiDeclaration,
                    resourceListing.apis.FirstOrDefault(api => api.path == apiDeclaration.resourcePath)
                )).OrderBy(e => e.Name).ToList()
            };
        }
    }
}