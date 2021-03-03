using System;
using System.Collections.Generic;
using System.Text;
using HR.Framework.Core.AssemblyHelper;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Framework.Core.DependencyInjection
{
    public interface IRegistrar
    {
        void Register(IServiceCollection serviceCollection, IAssemblyDiscovery assemblyDiscovery);
    }
}
