using Autofac;
using TestProject.Abstraction;
using TestProject.MSSQLDataLayer;

namespace TestProject.WebFramework.DI.Modules
{
    public class RepositoryCapsuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
        }

    }
}