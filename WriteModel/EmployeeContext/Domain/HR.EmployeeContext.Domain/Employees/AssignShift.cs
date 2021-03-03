using System;
using System.Linq;
using HR.EmployeeContext.Domain.Employees.Exceptions;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees
{
    public class AssignShift : EntityBase
    {
        private readonly IShiftAcl shiftAcl;

        public decimal Index { get;private set; }
        public Guid EmployeeId { get;private set; }
        public DateTime StartDate { get;private set; }
        public Guid ShiftId { get;private set; }

        public AssignShift(IShiftAcl shiftAcl, Guid employeeId, Guid shiftId, decimal index, DateTime startDate)
        {
            this.shiftAcl = shiftAcl;
            SetIndex(shiftAcl, shiftId, index);
            EmployeeId = employeeId;
            ShiftId = shiftId;
            SetStartDate(startDate);
        }

        private void SetStartDate(DateTime startDate)
        {
            if (DateTime.Now > startDate)
                throw new ShiftSegmentStartDateIsNotValid();
            StartDate = startDate;
        }

        private void SetIndex(IShiftAcl shiftAcl, Guid shiftId, decimal index)
        {
            if (!(shiftAcl.GetShiftSegmentDto(shiftId).Any(c => c.Index == index)))
                throw new IndexISOutOfRangeException();
            Index = index;
        }
    }
}
