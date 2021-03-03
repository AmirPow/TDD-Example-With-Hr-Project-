
using HR.EmployeeContext.ApplicationService.Contracts.Employees;

namespace HR.EmployeeContext.Facade.Contracts
{
    public interface IEmployeeCommandFacade
    {
        void CreateEmployee(EmployeeCreateCommand command);
        void UpdateEmployee(EmployeeUpdateCommand command);
        void RemoveEmployee(EmployeeDeleteCommand command);
        void AddContract(EmployeeCreateContract command);
        void RemoveContract(EmployeeRemoveContract command);
        void UpdateContract(EmployeeUpdateContract command);
        void AddAssignShift(EmployeeAssignShiftCommand command);
        void AddIO(EmployeeIOCommand command);
    }
}
