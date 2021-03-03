using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Framework.Core.DependencyInjection
{
    public interface IDiContainer
    {
        T Resolve<T>();
    }
}
