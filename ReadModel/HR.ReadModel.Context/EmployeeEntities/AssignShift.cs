using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.EmployeeEntities
{
    public partial class AssignShift
    {
        public Guid Id { get; set; }
        public Guid SegmentId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ShiftId { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ShiftSegment Segment { get; set; }
    }
}
