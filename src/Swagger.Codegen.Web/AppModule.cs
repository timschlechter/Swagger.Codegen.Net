using Nancy;
using Swagger.Codegen.Web.Models;

namespace Swagger.Codegen.Web
{
    public class AppModule : NancyModule
    {
        public AppModule(AppInfo appInfo)
        {
            Get["/"] = _ => View["index", appInfo];
        }
    }
}