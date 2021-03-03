using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.EmployeeEntities
{
    public partial class ShiftSegment
    {
        public ShiftSegment()
        {
            AssignShifts = new HashSet<AssignShift>();
        }

        public Guid Id { get; set; }
        public Guid ShiftId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public virtual Shift Shift { get; set; }
        public virtual ICollection<AssignShift> AssignShifts { get; set; }
    }
}
