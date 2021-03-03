using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Facade.Contracts;
using HR.ReadModel.Queries.Contracts.Employees;
using HR.ShiftContext.ApplicationService.Contracts.Shifts;
using HR.ShiftContext.Facade.Contracts;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeCommandFacade employeeCommandFacade;
        private readonly IShiftCommandFacade shiftCommandFacade;


        public HomeController(ILogger<HomeController> logger, 
                              IEmployeeCommandFacade employeeCommandFacade , 
                              IShiftCommandFacade shiftCommandFacade )
        {
            _logger = logger;
            this.employeeCommandFacade = employeeCommandFacade;
            this.shiftCommandFacade = shiftCommandFacade;
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeCreateCommand command)
        {
            //var fname = Request.Form["fName"];
            employeeCommandFacade.CreateEmployee(command);

            return RedirectToAction("SignUp");
        }

        [HttpPost]
        public IActionResult CreateShift(ShiftCreateCommand command)
        {
     
            shiftCommandFacade.ShiftCreate(command);

            return RedirectToAction("ShiftTitle");
        }

        [HttpPost]
        public IActionResult AddShiftSegment(ShiftSegmentAddCommand command)
        {

            shiftCommandFacade.ShiftSegmentAdd(command);

            return RedirectToAction("ShiftSegments");
        }


        [HttpPost]
        public IActionResult AssignShift(EmployeeAssignShiftCommand command)
        {

            employeeCommandFacade.AddAssignShift(command);

            return RedirectToAction("EmployeeAssignShift");
        }

        [HttpPost]
        public IActionResult AddContracts(EmployeeCreateContract command)
        {

            employeeCommandFacade.AddContract(command);

            return RedirectToAction("Contracts");
        }

        [HttpPost]
        public IActionResult AddIOs(EmployeeIOCommand command)
        {

            employeeCommandFacade.AddIO(command);

            return RedirectToAction("IO");
        }


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult ShiftTitle()
        {
            return View();
        }

        public IActionResult ShiftSegments()
        {
            return View();
        }

        public IActionResult EmployeeAssignShift()
        {
            return View();
        }

        public IActionResult Contracts()
        {
            return View();
        }


        public IActionResult IO()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}