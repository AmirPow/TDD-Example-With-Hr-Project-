using System;
using HR.Framework.Core.ApplicationService;

namespace HR.ShiftContext.ApplicationService.Contracts.Shifts
{
    public class ShiftSegmentUpdateCommand : Command
    {
        public Guid ShiftId { get; set; }
        public Guid SegmentId { get; set; }
        public TimeSpan  StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


    }
}
