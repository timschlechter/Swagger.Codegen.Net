using Nancy;
using Nancy.Conventions;

namespace Swagger.Codegen.Web
{
    public class Boostrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("assets", "Content"));
        }
    }
}