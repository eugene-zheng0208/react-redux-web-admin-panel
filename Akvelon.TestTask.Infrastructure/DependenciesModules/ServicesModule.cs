using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace Akvelon.TestTask.Infrastructure.DependenciesModules
{
    /// <summary>
    /// Autofac services dependencies setup module
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class ServicesModule : Module
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
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Akvelon.TestTask.Services")))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
