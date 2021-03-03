using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HR.Framework.Core.Persistence;
using HR.Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.Infrastructure.Persistence.Shifts
{
    public class ShiftRepository : RepositoryBase<Shift>, IShiftRepository
    {

        public ShiftRepository(IDbContext context) : base(context)
        {
        }
        public void Create(Shift shift)
        {
            base.Create(shift);
        }

        public Shift GetShift(Guid shiftId)
        {
            return GetById(shiftId);
        }

        public void Update(Shift shift)
        {
            base.Update(shift);
        }

        public void Remove(Shift shift)
        {
            base.Remove(shift);
        }


        protected override IEnumerable<Expression<Func<Shift, dynamic>>> GetAggregateExpression()
        {
            yield return s => s.ShiftSegments;
        }
    }
}
