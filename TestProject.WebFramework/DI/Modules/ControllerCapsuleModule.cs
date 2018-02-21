using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using TestProject.WebFramework.References;
using Module = Autofac.Module;

namespace TestProject.WebFramework.DI.Modules
{
    public class ControllerCapsuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register the MVC Controllers
            builder.RegisterControllers(ReferencedAssemblies.Web);
            // Register the Web API Controllers
            builder.RegisterApiControllers(ReferencedAssemblies.Web);
        }
    }
}
