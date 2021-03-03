using System.Linq;
using HR.Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contracts.Shifts;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftSegmentRemoveCommandHandler : ICommandHandler<ShiftSegmentRemoveCommand>
    {
        private readonly IShiftRepository shiftRepository;
        public ShiftSegmentRemoveCommandHandler(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }
        public void Execute(ShiftSegmentRemoveCommand command)
        {
            var shift = shiftRepository.GetShift(command.ShiftId);
            var shiftSegment = shift.ShiftSegments.Single(s => s.Id == command.SegmentId);
            shift.RemoveShiftSegment(shiftSegment);
        }
    }
}
