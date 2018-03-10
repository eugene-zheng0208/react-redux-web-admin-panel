using System.Reflection;
using Akvelon.TestTask.Repositories.Interfaces;
using Akvelon.TestTask.Repositories.Transactions;
using Autofac;
using Module = Autofac.Module;

namespace Akvelon.TestTask.Infrastructure.DependenciesModules
{
    /// <summary>
    /// Autofac repositories dependencies setup module
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class RepositoriesModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Akvelon.TestTask.Repositories")))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductTransactions>().As<IProductTransactions>();
        }
    }
}
