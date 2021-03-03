using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Core.Persistence;

namespace HR.ShiftContext.Domain.Shifts.Services
{
    public interface IShiftRepository : IRepository 
    {
        void Create(Shift shift);
        Shift GetShift(Guid shiftId);
        void Update(Shift shift);
        void Remove(Shift shift);
    }
}
