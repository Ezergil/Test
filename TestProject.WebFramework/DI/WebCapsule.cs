using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace TestProject.WebFramework.DI
{
    public static class WebCapsule
    {
        public static void Initialize(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            DependencyRegistrator.Register(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}