using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Framework.Core.Persistence
{
    public interface IDbContext:IDisposable
    {
        int SaveChanges();
        void Migrate();
    }
}
