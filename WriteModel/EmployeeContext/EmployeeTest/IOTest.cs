using System;
using System.Linq;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Exceptions;
using HR.EmployeeContext.Domain.Employees.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class IOTest 
    {

        private readonly Mock<IEmployeeRepository> employeeRepository =
            new Mock<IEmployeeRepository>();

        [TestInitialize]
        public void Setup()
        {
            employeeRepository.Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(true);
        }

        public Employee InitEmployee()
        {
            return new Employee();
        }

        public IO InitIO(
            Guid employeeId = new Guid(),
            DateTime Date = new DateTime(),
            TimeSpan ArrivalTime = new TimeSpan(),
            TimeSpan ExitTime = new TimeSpan())
        {
            return new IO(employeeRepository.Object, employeeId, Date, ArrivalTime, ExitTime);
        }

        [TestMethod, TestCategory("I/O")]
        [ExpectedException(typeof(IOEmployeeIdNullException))]
        public void EmployeeIdOfIOIsNotExist_ThrowException()
        {
            var employeeId = Guid.NewGuid();
            employeeRepository.
                Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(false);
            InitIO(employeeId: employeeId);

        }

        [TestMethod, TestCategory("I/O")]
        public void employeeIDValidation_Retrieve()
        {
            var employee = InitEmployee();
            var io = InitIO(employee.Id);

            Assert.AreEqual(io.EmployeeId , employee.Id);
        }

        [TestMethod, TestCategory("I/O")]
        public void DateValidation_Retrieve()
        {
            var date = new DateTime(2020,11,11);
            var io = InitIO(Date:date);

            Assert.AreEqual(io.Date, date);
        }

        [TestMethod, TestCategory("I/O")]
        public void ArrivalTimeValidation_Retrieve()
        {
            var arrivalTime = new TimeSpan(08,00,00);
            var io = InitIO(ArrivalTime:arrivalTime);

            Assert.AreEqual(io.ArrivalTime, arrivalTime);
        }

        [TestMethod, TestCategory("I/O")]
        public void ExitTimeValidation_Retrieve()
        {
            var exitTime = new TimeSpan(18, 00, 00);
            var io = InitIO(ExitTime: exitTime);

            Assert.AreEqual(io.ExitTime, exitTime);
        }

    }
}
