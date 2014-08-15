using AutoMapper;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Responses.Negotiation;
using Swagger.Codegen.CodegenProcessors.CSharp;
using Swagger.Codegen.Web.Api.Models;

namespace Swagger.Codegen.Web
{
    public class Boostrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides((c) =>
                {
                    c.ResponseProcessors.Clear();
                    c.ResponseProcessors.Add(typeof(JsonProcessor));
                });
            }
        }

        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, IPipelines pipelines)
        {
            Mapper.CreateMap<ICodegenProcessor, CodegenProcessorModel>();
            base.ApplicationStartup(container, pipelines);
        }

        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            container.RegisterMultiple(
                typeof(ICodegenProcessor),
                new[]
				{
					typeof(CSharpProcessor)
				}
            );

            base.ConfigureApplicationContainer(container);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("", "app"));
        }
    }
}