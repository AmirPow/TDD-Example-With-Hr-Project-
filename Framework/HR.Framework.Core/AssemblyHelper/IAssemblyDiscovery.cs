using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Framework.Core.AssemblyHelper
{
    public interface IAssemblyDiscovery
    {
        IEnumerable<T> DiscoverInstance<T>(string searchNamespace);
        IEnumerable<Type> DiscoverTypes<TInterface>(string searchNamespace);

    }
}
