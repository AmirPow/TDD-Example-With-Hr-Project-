using HR.EmployeeContext.Domain.Employees.ACL.ShiftContext.Dto;

namespace HR.EmployeeContext.Domain.Employees.ACL.ShiftContext
{
    public interface IShiftAclRepository
    {
          ShiftSegmentDto SegmentDto();
    }
}
