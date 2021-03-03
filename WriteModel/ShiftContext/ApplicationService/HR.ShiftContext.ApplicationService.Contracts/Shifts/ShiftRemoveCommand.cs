using System;
using HR.Framework.Core.ApplicationService;

namespace HR.ShiftContext.ApplicationService.Contracts.Shifts
{
    public class ShiftRemoveCommand:Command
    {
        public Guid ShiftId { get; set; }
    }
}
