using System.Linq;
using HR.Framework.Application;
using HR.Framework.AssemblyHelper;
using HR.Framework.Core.ApplicationService;
using HR.Framework.Core.AssemblyHelper;
using HR.Framework.Core.DependencyInjection;
using HR.Framework.Core.Domain;
using HR.Framework.Core.Facade;
using HR.Framework.Core.Persistence;
using Microsoft.Extensions.DependencyInjection;



namespace HR.Framework.DependencyInjection
{
    public abstract class RegistrarBase<TRegistrar> : IRegistrar
    {
        private IServiceCollection _serviceCollection;
        private IAssemblyDiscovery _assemblyDiscovery;
        private readonly string _namespace;
        protected RegistrarBase()
        {

            var nameSpaceSpell = typeof(TRegistrar).Namespace?.Split('.');
            _namespace = nameSpaceSpell?[0] + "." + nameSpaceSpell?[1];
        }
        public void Register(IServiceCollection serviceCollection, IAssemblyDiscovery assemblyDiscovery)
        {
            _serviceCollection = serviceCollection;
            _assemblyDiscovery = assemblyDiscovery;
            RegisterFramework();
            RegisterTransient<IEntityMapping>();
            RegisterTransient<IRepository>();
            RegisterTransient<ICommandFacade>();
            RegisterTransient<IHandler>();
            RegisterTransient<IDomainService>();
            RegisterTransient<IACLService>();
        }

        private void RegisterFramework()
        {
            _serviceCollection.AddScoped<IAssemblyDiscovery, AssemblyDiscovery>(a => new AssemblyDiscovery("HR*.dll"));
            _serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            _serviceCollection.AddScoped<IDiContainer, DiContainer>();
            _serviceCollection.AddScoped<ICommandBus, CommandBus>();
        }
        private void RegisterTransient<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddTransient(baseInterface, type);
            }
        }
        private void RegisterScope<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddScoped(baseInterface, type);
            }
        }
        private void RegisterSingleton<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddSingleton(baseInterface, type);
            }
        }
    }
}
