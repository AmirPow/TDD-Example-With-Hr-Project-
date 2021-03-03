using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Framework.Core.ApplicationService
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }
}
