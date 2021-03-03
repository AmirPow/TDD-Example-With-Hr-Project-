using HR.Framework.Core.Domain;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface INationalCodeDuplicationChecker :IDomainService
    {
        bool IsDuplicated(string nationalCode);
    }
}
