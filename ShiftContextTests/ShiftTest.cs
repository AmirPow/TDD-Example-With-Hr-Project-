using System;
using System.Linq;
using HR.Framework.Domain;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ShiftContextTests
{
    [TestClass]
    public class ShiftTest : EntityBase
    {


        public Shift InitShift(string title = "Information")
        {
            return new Shift(title);
        }

        public ShiftSegment InitShiftSegment(
            Guid shiftId = new Guid(),
            decimal index = 0,
            TimeSpan startTime = new TimeSpan(),
            TimeSpan endTime = new TimeSpan())
        {
            return new ShiftSegment(shiftId, index, startTime, endTime);
        }


        [TestMethod, TestCategory("Shift")]
        [ExpectedException(typeof(ShiftTitleMustNotBeEmptyOrWhiteSpaceExceptions))]
        public void ShiftTitleEmptyOrWhiteSpace_ThrowException()
        {
            string title = " ";
            InitShift(title);
        }

        [TestMethod, TestCategory("Shift")]
        public void TitleValidation_Retrieve()
        {
            string title = "Information";
            var shift = InitShift(title);
            Assert.AreEqual(shift.Title, title);
        }

        [TestMethod, TestCategory("Index")]
        [ExpectedException(typeof(ShiftSegmentIndexCanNotBeDuplicateExceptions))]
        public void ShiftSegmentIndexBeDuplicated_ThrowException()
        {
            var shift = InitShift();
            var shiftSegment = InitShiftSegment(shiftId: shift.Id, index: 1);
            shift.AddSegment(shiftSegment);

            var segment = InitShiftSegment(shiftId: shift.Id, index: 1);
            shift.AddSegment(segment);
        }

        [TestMethod, TestCategory("Index")]
        [ExpectedException(typeof(ShiftSegmentIdIsNotExistsExceptions))]
        public void ShiftSegmentIdIsNotExists_ThrowException()
        {

            var shift = InitShift();
            var newSegment = Guid.NewGuid();
            
            shift.UpdateSegment(newSegment, InitShiftSegment());
        }


        [TestMethod, TestCategory("Index")]
        [ExpectedException(typeof(ShiftSegmentIndexCanBeDuplicatedInUpdateExceptions))]
        public void ShiftSegmentIndexCanBeDuplicatedInUpdate_ThrowException()
        {
            var shift = InitShift();
            var oldSegment = InitShiftSegment(
                shiftId: shift.Id, 
                index: 1, 
                startTime: new TimeSpan(08, 00, 00), 
                endTime: new TimeSpan(16, 00, 00)
                );

            var oldSegment2 = InitShiftSegment(
                shiftId: shift.Id,
                index: 2,
                startTime: new TimeSpan(09, 00, 00),
                endTime: new TimeSpan(17, 00, 00)
            );
            shift.AddSegment(oldSegment);
            shift.AddSegment(oldSegment2);
            
            var newSegment = InitShiftSegment(
                index: 2,
                startTime: new TimeSpan(08, 00, 00),
                endTime: new TimeSpan(16, 00, 00));

            shift.UpdateSegment(oldSegment.Id, newSegment);
        }
    }
}
