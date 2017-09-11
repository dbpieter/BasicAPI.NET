
using System;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;

namespace BasicApi.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();

            httpConfiguration.Formatters.Remove(httpConfiguration.Formatters.XmlFormatter);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(AppDomain.CurrentDomain.GetAssemblies());

            builder.RegisterWebApiFilterProvider(httpConfiguration);

            var container = builder.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(httpConfiguration);
            app.UseWebApi(httpConfiguration);

            httpConfiguration.EnsureInitialized();
        }
    }
}
