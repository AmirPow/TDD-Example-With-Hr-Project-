using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.EmployeeEntities
{
    public partial class Shift
    {
        public Shift()
        {
            ShiftSegments = new HashSet<ShiftSegment>();
        }

        public Guid Id { get; set; }
        public string ShiftTitle { get; set; }

        public virtual ICollection<ShiftSegment> ShiftSegments { get; set; }
    }
}
