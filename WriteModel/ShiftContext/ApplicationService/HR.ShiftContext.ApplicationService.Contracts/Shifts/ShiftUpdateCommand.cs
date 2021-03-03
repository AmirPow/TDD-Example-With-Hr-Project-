using System;
using HR.Framework.Core.ApplicationService;

namespace HR.ShiftContext.ApplicationService.Contracts.Shifts
{
    public class ShiftUpdateCommand:Command
    {
        public Guid ShiftId { get; set; }
        public string ShiftTitle { get; set; }
    }
}
