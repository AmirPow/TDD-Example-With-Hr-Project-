using HR.Framework.Core.ApplicationService;

namespace HR.ShiftContext.ApplicationService.Contracts.Shifts
{
    public class ShiftCreateCommand:Command
    {
        public string ShiftTitle { get; set; }
    }
}
