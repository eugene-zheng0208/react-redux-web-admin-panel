using Akvelon.TestTask.DataAccessLayer.Contexts;
using Autofac;

namespace Akvelon.TestTask.Infrastructure.DependenciesModules
{
    /// <summary>
    /// Autofac data access layer dependencies setup module
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class DataAccessLayerModule : Module
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
            builder.RegisterType<AdventureWorks2014Context>().As<IAdventureWorks2014Context>();
        }
    }
}
