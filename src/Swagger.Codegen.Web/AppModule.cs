using Nancy;

namespace Swagger.Codegen.Web
{
    public class AppModule : NancyModule
    {
        public AppModule()
        {
            Get["/"] = _ => View["index"];
        }
    }
}