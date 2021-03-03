using System;
namespace HR.EmployeeContext.Domain.Contracts
{
    public class ShiftSegmentDto
    {
        public Guid ShiftId { get; set; }
        public decimal Index { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
