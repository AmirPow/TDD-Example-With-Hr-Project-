using System;
using System.Collections.Generic;
using System.Linq;
using HR.EmployeeContext.Domain.Contracts;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Exceptions;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.ShiftContext.Domain.Shifts;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class AssignShiftTest 
    {
        private readonly Mock<IShiftAcl> shiftAcl = new Mock<IShiftAcl>();

        [TestInitialize]
        public void Setup()
        {
            shiftAcl.Setup(s => s.GetShiftSegmentDto(It.IsAny<Guid>())).Returns(new List<ShiftSegmentDto>
            {
                new ShiftSegmentDto()
                {
                    ShiftId = new Guid(),
                    EndTime = new TimeSpan(),
                    StartTime = new TimeSpan(),
                    Index = 1
                }
                ,
                new ShiftSegmentDto()
                {
                    ShiftId = new Guid(),
                    EndTime = new TimeSpan(),
                    StartTime = new TimeSpan(),
                    Index = 2
                }
            });
        }

        public Employee InitEmployee()
        {
            return new Employee();
        }

        public AssignShift InitAssignShift(
            Guid employeeId = new Guid(),
            Guid shiftId = new Guid() ,
            decimal index =1,
            DateTime startDate= new DateTime())
        {
            return new AssignShift(shiftAcl.Object,employeeId, shiftId,index, startDate);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexISOutOfRangeException))]
        public void IndexISOutOfRange_ThrowException()
        {
            var shift = new Shift("Test");
            var Segment = new ShiftSegment(shift.Id, 1, new TimeSpan(), new TimeSpan());
            var Segment2 = new ShiftSegment(shift.Id, 2, new TimeSpan(), new TimeSpan());
            shiftAcl.Object.GetShiftSegmentDto(Segment.Id);
            shiftAcl.Object.GetShiftSegmentDto(Segment2.Id); 
            InitAssignShift(index: 3, shiftId: shift.Id);
        }


        [TestMethod]
        public void IndexValidation_retrieve()
        {
            var startDate = new DateTime(2022, 01, 1 );
            var index = 1;
            var assignSift = InitAssignShift(index: index, startDate:startDate);
            Assert.AreEqual(assignSift.Index, index);
        }


        [TestMethod]
        public void EmployeeIdValidation_retrieve()
        {
            var startDate = new DateTime(2022, 01, 1);
            var employeeId = Guid.NewGuid();
            var assignSift = InitAssignShift(employeeId:employeeId, startDate: startDate);
            Assert.AreEqual(assignSift.EmployeeId ,employeeId );
        }

        [TestMethod]
        public void ShiftIdValidation_retrieve()
        {
            var startDate = new DateTime(2022, 01, 1);
            var shiftId = Guid.NewGuid();
            var assignSift = InitAssignShift(shiftId: shiftId, startDate: startDate);
            Assert.AreEqual(assignSift.ShiftId, shiftId);
        }

        [TestMethod]
        [ExpectedException(typeof(ShiftSegmentStartDateIsNotValid))]
        public void ShiftSegmentStartDateIsNotValid_ThrowException()
        {
            var startDate = new DateTime(2020,11,1);
            var assignSift = InitAssignShift(startDate: startDate);
        }

        [TestMethod]
        public void ShiftSegmentStartDateValidation_retrieve()
        {
            var startDate = new DateTime(2021, 12, 1);
            var assignSift = InitAssignShift(startDate: startDate);
            Assert.AreEqual(assignSift.StartDate, startDate);
        }


    }
}
