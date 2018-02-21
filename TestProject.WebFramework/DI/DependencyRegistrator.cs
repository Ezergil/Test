using Autofac;
using TestProject.MSSQLDataLayer;
using TestProject.WebFramework.DI.Modules;

namespace TestProject.WebFramework.DI
{
    internal static class DependencyRegistrator
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().As<IDbContext>().InstancePerRequest();

            builder.RegisterModule<RepositoryCapsuleModule>();
            builder.RegisterModule<ServiceCapsuleModule>();
            builder.RegisterModule<ControllerCapsuleModule>();
        }
    }
}