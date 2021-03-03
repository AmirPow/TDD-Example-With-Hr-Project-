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
    public class ContractTest
    {
        private readonly Mock<IEmployeeRepository> employeeRepository =
            new Mock<IEmployeeRepository>();
        

        [TestInitialize]
        public void Setup()
        {
            employeeRepository.
                Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(true);
        }


        public Employee InitEmployee()
        {
            return new Employee();
        }

        public Contract InitContract(
            Guid employeeId=new Guid(),
            DateTime startDate = new DateTime(), 
            DateTime endDate = new DateTime())
        {
            return new Contract(employeeRepository.Object, employeeId, startDate, endDate);
        }


        [TestMethod, TestCategory("Contract")]
        [ExpectedException(typeof(ContractEndDateCouldNotBeLessThanStartDateException))]
        public void ContractEndDateLessThanStartDate_ThrowException()
        {
            DateTime startDate = new DateTime(2021, 02, 02);
            DateTime endDate = new DateTime(2020, 02, 02);
            InitContract(startDate: startDate, endDate: endDate);
        }

        [TestMethod, TestCategory("Contract")]
        [ExpectedException(typeof(EmployeeIdOfContractIsNotExist))]
        public void EmployeeIdOfContractIsNotExist_ThrowException()
        {
            DateTime startDate = new DateTime(2020, 02, 02);
            DateTime endDate = new DateTime(2022, 02, 02);
            employeeRepository.
                Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(false);
            InitContract(startDate: startDate, endDate: endDate);
        }

        [TestMethod, TestCategory("Contract")]
        public void AddContractToEmployee_Retrieve()
        {
            DateTime startDate = new DateTime(2020, 02, 02);
            DateTime endDate = new DateTime(2022, 02, 02);
            var contract = InitContract(startDate: startDate, endDate: endDate);
            var employee = InitEmployee();
            employee.AddContract(contract);

            var isContractExist = employee.Contracts.Any(a => a == contract);
            Assert.AreEqual(isContractExist, true);
        }
    }
}
