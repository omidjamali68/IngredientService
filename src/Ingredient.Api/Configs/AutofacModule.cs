using Autofac;
using Ingredient.Application.Interfaces;
using Ingredient.Persistence.EF.Units;
using Ingredient.Persistence.EF;
using Ingredient.Application;

namespace Ingredient.Api.Configs
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                    .As<IUnitOfWork>()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(UnitRepository).Assembly)
                    .AssignableTo<IRepository>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}
