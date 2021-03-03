using System;
using System.Collections.Generic;
using System.Linq;
using HR.EmployeeContext.Domain.Contracts;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Exceptions;
using HR.EmployeeContext.Domain.Employees.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class EmployeeTest
    {
        private readonly Mock<INationalCodeDuplicationChecker> _nationalCodeDuplicationChecker =
            new Mock<INationalCodeDuplicationChecker>();

        private readonly Mock<IEmployeeRepository> _employeeRepository =
            new Mock<IEmployeeRepository>();

        private readonly Mock<IShiftAcl> _shiftAcl = new Mock<IShiftAcl>();


        [TestInitialize]
        public void Setup()
        {
            _nationalCodeDuplicationChecker.
                Setup(n => n.IsDuplicated(It.IsAny<string>())).Returns(false);

            _employeeRepository.Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(true);

            _shiftAcl.Setup(s => s.GetShiftSegmentDto(It.IsAny<Guid>())).Returns(new List<ShiftSegmentDto>
                {
                    new ShiftSegmentDto()
                    {
                        ShiftId = new Guid(),
                        StartTime = new TimeSpan(08,00,00),
                        EndTime = new TimeSpan(16,00,00),
                        
                        Index = 1
                    }
                    ,
                    new ShiftSegmentDto()
                    {
                        ShiftId = new Guid(),
                        StartTime = new TimeSpan(09,00,00),
                        EndTime = new TimeSpan(17,00,00),
                        Index = 2
                    }
                    ,
                    new ShiftSegmentDto()
                    {
                        ShiftId = new Guid(),
                        StartTime = new TimeSpan(00,00,00),
                        EndTime = new TimeSpan(00,00,00),
                        Index = 3
                    }
                });
        }

        public Employee InitEmployee(
            string name = "Amir",
            string nationalCode = "1361215739")
        {
            return new Employee(_nationalCodeDuplicationChecker.Object,_shiftAcl.Object, name, nationalCode);
        }

        public Contract InitContract(Guid employeeId = new Guid(),
            DateTime startDate = new DateTime(), DateTime endDate = new DateTime())
        {
            return new Contract(_employeeRepository.Object, employeeId, startDate, endDate);
        }

        public AssignShift InitAssignShift(
            Guid employeeId = new Guid(),
            Guid shiftId = new Guid(),
            decimal index = 1,
            DateTime startDate = new DateTime())
        {
            return new AssignShift(_shiftAcl.Object, employeeId, shiftId, index, startDate);
        }

        public IO InitIO(
            Guid employeeId = new Guid(),
            DateTime date = new DateTime(),
            TimeSpan arrivalTime = new TimeSpan(),
            TimeSpan exitTime = new TimeSpan())
        {
            return new IO(_employeeRepository.Object, employeeId, date, arrivalTime, exitTime);
        }


        [TestMethod, TestCategory("Name")]
        [ExpectedException(typeof(FirstNameIsRequiredException))]
        [DataRow(" ")]
        [DataRow("   ")]
        [DataRow (null)]
        [DataRow("")]
        public void NameIsNullOrWhiteSpace_ThrowException(string name)
        {

            InitEmployee(name: name);
        }

        [TestMethod, TestCategory("Name")]
        public void NameValidation_Retrieve()
        {
            string name = "Amir";
            var employee = InitEmployee(name: name);
            Assert.AreEqual(employee.Name, name);
        }

        [TestMethod, TestCategory("NationalCode")]
        [ExpectedException(typeof(NationalCodeIsRequiredException))]
        public void NationalCodeIsNullOrWhiteSpace_ThrowException()
        {
            string nationalCode = " ";
            InitEmployee(nationalCode: nationalCode);
        }

        [TestMethod, TestCategory("NationalCode")]
        [ExpectedException(typeof(NationalCodeMustBeDigitException))]
        public void NationalCodeIsNotDigit_ThrowException()
        {
            string nationalCode = "123n";
            InitEmployee(nationalCode: nationalCode);
        }

        [TestMethod, TestCategory("NationalCode")]
        [ExpectedException(typeof(NationalCodeMustBeUniqueException))]
        public void NationalCodeIsDuplicated_ThrowException()
        {
            string nationalCode = "1360460810";
            _nationalCodeDuplicationChecker.
                Setup(n => n.IsDuplicated(nationalCode)).Returns(true);
            InitEmployee(nationalCode: nationalCode);
        }

        [TestMethod, TestCategory("Contracts")]
        [ExpectedException(typeof(EmployeeStartDateOfContractConflictedWithOtherContracts))]
        public void EmployeeStartDateOfContractConflictedWithOtherContracts_ThrowException()
        {
            _employeeRepository.
                Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(true);
            var contractStartDate = new DateTime(2021, 02, 10);
            var contractEndDate = new DateTime(2021, 03, 02);

            var employee = FillEmployee();
            var contract = InitContract(startDate: contractStartDate, endDate: contractEndDate);
            employee.AddContract(contract);
        }

        [TestMethod, TestCategory("Contracts")]
        [ExpectedException(typeof(EmployeeEndDateOfContractConflictedWithOtherContracts))]
        public void EmployeeEndDateOfContractConflictedWithOtherContracts_ThrowException()
        {

            _employeeRepository.
                Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(true);
            var contractStartDate = new DateTime(2021, 02, 11);
            var contractEndDate = new DateTime(2021, 03, 12);

            var employee = FillEmployee();
            var contract = InitContract(startDate: contractStartDate, endDate: contractEndDate);
            employee.AddContract(contract);
        }

        [TestMethod, TestCategory("Contracts")]
        [ExpectedException(typeof(EmployeeStartAndEndDateOfContractConflictedWithOtherContracts))]
        public void EmployeeStartAndEndDateOfContractConflictedWithOtherContracts_ThrowException()
        {

            _employeeRepository.
                Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(true);
            var contractStartDate = new DateTime(2021, 01, 09);
            var contractEndDate = new DateTime(2021, 11, 11);

            var employee = FillEmployee();
            var contract = InitContract(startDate: contractStartDate, endDate: contractEndDate);
            employee.AddContract(contract);
        }

        [TestMethod, TestCategory("Contracts")]
        public void EmployeeContractDoesNotHaveConflictWithOtherContracts_Retrieve()
        {
            _employeeRepository.
                Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(true);
            var contractStartDate = new DateTime(2021, 11, 11);
            var contractEndDate = new DateTime(2021, 12, 11);

            var employee = FillEmployee();
            var contract = InitContract(startDate: contractStartDate, endDate: contractEndDate);
            employee.AddContract(contract);

        }
        [TestMethod, TestCategory("AssignShift")]
        public void EmployeeAddAssignShiftValidation_Retrieve()
        {
            var employee = InitEmployee();
            var startDate = new DateTime(2022, 01, 01);
            var assignShift = InitAssignShift(startDate: startDate);
            employee.AddAssignShift(assignShift);
            var employeeAssignShifts =
                employee.AssignShifts.Any(c => c == assignShift);
            Assert.AreEqual(employeeAssignShifts, true);
        }


        [TestMethod, TestCategory("I/O")]
        [ExpectedException(typeof(EnteredTimeIsNotInSegmentInside))]
        public void EnteredTimeInSegmentInside_ThrowException()
        {
            var employee = InitEmployee();
            var shiftId = Guid.NewGuid();

            var a1 = InitAssignShift(employeeId: employee.Id,
                shiftId: shiftId,
                index: 3,
                startDate: new DateTime(2021, 01, 01));

            var a2 = InitAssignShift(employeeId: employee.Id,
                shiftId: shiftId,
                index: 2,
                startDate: new DateTime(2021, 05, 01));

            employee.AssignShifts.Add(a1);
            employee.AssignShifts.Add(a2);

            var assignedShift = InitAssignShift(
                employeeId: employee.Id,
                shiftId: shiftId,
                index: 3 ,
                startDate: new DateTime(2021, 12, 01));

            var arrivalTime = new TimeSpan(06, 00, 00);
            var exitTime = new TimeSpan(16, 00, 00);

            var io = InitIO(
                employeeId: employee.Id,
                date: new DateTime(2021, 12, 02),
                arrivalTime: arrivalTime,
                exitTime: exitTime);

            _employeeRepository.Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(false);

            employee.AddAssignShift(assignedShift);
            employee.AddIO(io);
        }



        [TestMethod, TestCategory("I/O")]
        public void IOValidation_Retrieve()
        {
            var employee = InitEmployee();
            var startDate = new DateTime(2022, 01, 01);

            var assignedShift = InitAssignShift(startDate:startDate);
            employee.AddAssignShift(assignedShift);

            var arrivalTime = new TimeSpan(09, 00, 00);
            var exitTime = new TimeSpan(16, 00, 00);

            var io = InitIO(
                employeeId: employee.Id,
                date: new DateTime(2022, 12, 03),
                arrivalTime: arrivalTime,
                exitTime: exitTime);

            _employeeRepository.Setup(e => e.IsExist(It.IsAny<Guid>())).Returns(false);
            employee.AddIO(io);

            var employeeIOs =
                employee.IOs.Any(c => c.Id == io.Id);
            Assert.AreEqual(employeeIOs, true);
        }

        private Employee FillEmployee()
        {
            var employee = InitEmployee();
            var contract1 = InitContract(startDate: new DateTime(2021, 1, 10), endDate: new DateTime(2021, 2, 10));
            var contract2 = InitContract(startDate: new DateTime(2021, 3, 10), endDate: new DateTime(2021, 5, 10));
            var contract3 = InitContract(startDate: new DateTime(2021, 8, 10), endDate: new DateTime(2021, 11, 10));

            employee.AddContract(contract1);
            employee.AddContract(contract2);
            employee.AddContract(contract3);
            return employee;
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
