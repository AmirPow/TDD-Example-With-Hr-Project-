using System;
using HR.Framework.Core.ApplicationService;

namespace HR.ShiftContext.ApplicationService.Contracts.Shifts
{
    public class ShiftSegmentRemoveCommand : Command
    {
        public Guid ShiftId { get; set; }
        public Guid SegmentId { get; set; }

    }
}
