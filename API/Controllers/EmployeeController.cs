using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeCommandFacade commandFacade;
        
        public EmployeeController(IEmployeeCommandFacade commandFacade)
        {
            this.commandFacade = commandFacade;
        }

        [HttpPost()]
        public void CreateEmployee(EmployeeCreateCommand command)
        {
            commandFacade.CreateEmployee(command);
        }

        [HttpPost()]
        public void UpdateEmployee(EmployeeUpdateCommand command)
        {
            commandFacade.UpdateEmployee(command);
        }

        [HttpPost()]
        public void RemoveEmployee(EmployeeDeleteCommand command)
        {
            commandFacade.RemoveEmployee(command);
        }

        [HttpPost()]
        public void CreateIO(EmployeeIOCommand command)
        {
            commandFacade.AddIO(command);
        }

        [HttpPost()]
        public void CreateContract(EmployeeCreateContract command)
        {
            commandFacade.AddContract(command);
        }

        [HttpPost()]
        public void UpdateContract(EmployeeUpdateContract command)
        {
            commandFacade.UpdateContract(command);
        }

        [HttpPost()]
        public void RemoveContract(EmployeeRemoveContract command)
        {
            commandFacade.RemoveContract(command);
        }

        [HttpPost()]
        public void CreateAssignShift(EmployeeAssignShiftCommand command)
        {
            commandFacade.AddAssignShift(command);
        }



    }
}
