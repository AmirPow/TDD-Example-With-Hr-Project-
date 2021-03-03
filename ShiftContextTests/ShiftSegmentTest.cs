using System;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ShiftContextTests
{
    [TestClass]
    public class ShiftSegmentTest
    {
        public Shift InitShift(string title = "Information")
        {
            return new Shift(title);
        }
        public ShiftSegment InitShiftSegment(Guid shiftId = new Guid(), decimal index = 0,  TimeSpan startTime = new TimeSpan(), TimeSpan endTime = new TimeSpan())
        {
            return new ShiftSegment(shiftId, index,  startTime, endTime);
        }

        [TestMethod, TestCategory("ShiftSegment")]
        [ExpectedException(typeof(IndexMustMoreThanZeroExceptions))]
        public void IndexIsNegative_ThrowException()
        {
            decimal index = -1;
            InitShiftSegment(index: index);
        }

        [TestMethod]
        public void IndexValidation_Retrieve()
        {
            decimal index = 1;
            var shiftSegment = InitShiftSegment(index:index);
            Assert.AreEqual(shiftSegment.Index, index);
        }

        [TestMethod, TestCategory("ShiftSegment")]
        public void EmployeeIdValidation_Retrieve()
        {
            Guid shiftId = Guid.NewGuid();
            var shiftSegment = InitShiftSegment(shiftId: shiftId);
            Assert.AreEqual(shiftSegment.ShiftId, shiftId);
        }

        [TestMethod, TestCategory("ShiftSegment")]
        [ExpectedException(typeof(StartTimeMustBeLessThanEndTimeException))]
        public void StartTimeMustBeLessThanEndTime_ThrowException()
        {
            var startTime = new TimeSpan(17, 0, 0);
            var endTime = new TimeSpan(07, 0, 0);
            var shiftSegment = InitShiftSegment(startTime: startTime, endTime: endTime);
        }

        [TestMethod, TestCategory("ShiftSegment")]
        public void SegmentTimeValidation_Retrieve()
        {
            var startTime = new TimeSpan(07, 0, 0);
            var endTime = new TimeSpan(17, 0, 0);
            var shiftSegment = InitShiftSegment(startTime: startTime, endTime: endTime);
            Assert.AreEqual(shiftSegment.StartTime , startTime);
            Assert.AreEqual(shiftSegment.EndTime, endTime);
        }
    }
}
