using System.Globalization;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Facade.Contracts;
using HR.Framework.Application;
using HR.Framework.Core.ApplicationService;
using HR.Framework.Facade;

namespace HR.EmployeeContext.Facade
{
    public class EmployeeCommandFacade : FacadeCommandBase, IEmployeeCommandFacade
    {
        public EmployeeCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void CreateEmployee(EmployeeCreateCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void UpdateEmployee(EmployeeUpdateCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void RemoveEmployee(EmployeeDeleteCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void AddContract(EmployeeCreateContract command)
        {
            commandBus.Dispatch(command);
        }

        public void RemoveContract(EmployeeRemoveContract command)
        {
            commandBus.Dispatch(command);
        }

        public void UpdateContract(EmployeeUpdateContract command)
        {
            commandBus.Dispatch(command);
        }

        public void AddAssignShift(EmployeeAssignShiftCommand command)
        {
            commandBus.Dispatch(command);
        }

        public void AddIO(EmployeeIOCommand command)
        {
            commandBus.Dispatch(command);
        }
    }
}
