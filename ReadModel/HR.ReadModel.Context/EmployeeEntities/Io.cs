using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.EmployeeEntities
{
    public partial class Io
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public string ArrivalTime { get; set; }
        public string ExiTime { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
