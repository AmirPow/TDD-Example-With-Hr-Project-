using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.EmployeeContext.Domain.Contracts;
using HR.Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IShiftAcl : IACLService
    {
        List<ShiftSegmentDto> GetShiftSegmentDto(Guid shiftId);
    }
}
