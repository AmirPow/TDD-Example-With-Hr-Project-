using System;
using HR.Framework.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Framework.DependencyInjection
{
    public class DiContainer:IDiContainer
    {
        private readonly IServiceProvider serviceProvider;

        public DiContainer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T Resolve<T>()
        {
            return serviceProvider.GetRequiredService<T>();
        }
    }
}
