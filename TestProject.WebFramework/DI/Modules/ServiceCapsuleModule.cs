using System.Reflection;
using Autofac;
using TestProject.Abstraction;
using TestProject.WebFramework.References;
using Module = Autofac.Module;

namespace TestProject.WebFramework.DI.Modules
{
    public class ServiceCapsuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {                                                 
            builder.RegisterAssemblyTypes(ReferencedAssemblies.Services).
                Where(_ => _.Name.EndsWith("Service")).
                AsImplementedInterfaces().
                InstancePerRequest();

            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IService<>)).InstancePerRequest();

        }

    }
}