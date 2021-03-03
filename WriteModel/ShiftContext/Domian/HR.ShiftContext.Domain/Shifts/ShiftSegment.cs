using HR.Framework.Domain;
using HR.ShiftContext.Domain.Shifts.Exceptions;
using System;
using System.Linq;

namespace HR.ShiftContext.Domain.Shifts
{
    public class ShiftSegment :EntityBase
    {
        public Guid ShiftId { get; set; }
        public decimal Index { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public ShiftSegment(Guid shiftId , decimal index , TimeSpan startTime , TimeSpan endTime)
        {
            SetIndex(index);
            ShiftId = shiftId;
            SetTime(startTime, endTime);
        }

        public void SetTime(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime > endTime)
                throw new StartTimeMustBeLessThanEndTimeException();
            StartTime = startTime;
            EndTime = endTime;
        }

        private void SetIndex(decimal index)
        {
            if (index < 0)
                throw new IndexMustMoreThanZeroExceptions();
            Index = index;
        }
    }
}
