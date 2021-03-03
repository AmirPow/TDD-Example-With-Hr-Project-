using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HR.Framework.Core.Domain;
using HR.Framework.Domain;
using HR.ShiftContext.Domain.Shifts.Exceptions;

namespace HR.ShiftContext.Domain.Shifts
{
    public class Shift : EntityBase, IAggregateRoot<Shift>
    {
        public Shift(string title)
        {
            SetTitle(title);
        }

        public string Title { get; private set; }
        public ICollection<ShiftSegment> ShiftSegments { get; set; } = new HashSet<ShiftSegment>();

        public void AddSegment(ShiftSegment shiftSegment)
        {
            if (ShiftSegments.Where(c => c.ShiftId == shiftSegment.ShiftId)
                .Any(c => c.Index == shiftSegment.Index))
                throw new ShiftSegmentIndexCanNotBeDuplicateExceptions();
            ShiftSegments.Add(shiftSegment);
        }

        public void UpdateSegment(Guid shiftSegmentId, ShiftSegment newSegment)
        {

            var segment = ShiftSegments.SingleOrDefault(c => c.Id == shiftSegmentId);
            if (segment == null)

                throw new ShiftSegmentIdIsNotExistsExceptions();

            if ((ShiftSegments.Where(c => c.Index == newSegment.Index)
                 .Any(c => c.Id != segment.Id)))
                throw new ShiftSegmentIndexCanBeDuplicatedInUpdateExceptions();

            segment.StartTime = newSegment.StartTime;
            segment.EndTime = newSegment.EndTime;
            
            segment.Index = newSegment.Index;
        }
        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ShiftTitleMustNotBeEmptyOrWhiteSpaceExceptions();

            Title = title;
        }

        public void RemoveShiftSegment(ShiftSegment shiftSegment)
        {
            ShiftSegments.Remove(shiftSegment);
        }
    }
}
