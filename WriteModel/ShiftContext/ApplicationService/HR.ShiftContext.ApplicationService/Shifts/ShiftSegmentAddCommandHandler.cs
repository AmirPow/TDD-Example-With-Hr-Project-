using System.Linq;
using HR.Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contracts.Shifts;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftSegmentAddCommandHandler : ICommandHandler<ShiftSegmentAddCommand>
    {
        private readonly IShiftRepository shiftRepository;
        public ShiftSegmentAddCommandHandler(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }
        public void Execute(ShiftSegmentAddCommand command)
        {
            var shift = shiftRepository.GetShift(command.ShiftId);
            var shiftSegment = new ShiftSegment(shift.Id,command.Index, command.StartTime, command.EndTime);
            shift.AddSegment(shiftSegment);
        }
    }
}
