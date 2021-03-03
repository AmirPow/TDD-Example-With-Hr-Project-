using System;
using System.Collections.Generic;
using System.Linq;
using HR.EmployeeContext.Domain.Contracts;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees
{
    public class ShiftAclRepository : IShiftAcl
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftAclRepository(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public List<ShiftSegmentDto> GetShiftSegmentDto(Guid shiftId)
        {
            var shift = shiftRepository.GetShift(shiftId);

            var shiftSegmentsList =
                shift.ShiftSegments.Where(s => s.ShiftId == shiftId)
                    .Select(a =>new  ShiftSegmentDto()
                          {
                                ShiftId = a.ShiftId,
                                Index = a.Index,
                                StartTime = a.StartTime,
                                EndTime = a.EndTime
                    })
                    .ToList();

            return shiftSegmentsList;
        }
    }
}
