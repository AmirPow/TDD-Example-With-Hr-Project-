using System.Linq;
using HR.Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contracts.Shifts;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftSegmentUpdateCommandHandler : ICommandHandler<ShiftSegmentUpdateCommand>
    {
        private readonly IShiftRepository shiftRepository;
        public ShiftSegmentUpdateCommandHandler(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }
        public void Execute(ShiftSegmentUpdateCommand command)
        {
            var shift = shiftRepository.GetShift(command.ShiftId);
            var shiftSegment = shift.ShiftSegments.Single(s => s.Id == command.SegmentId);
            shift.ShiftSegments.Add(shiftSegment);
            shiftSegment.SetTime(command.StartTime , command.EndTime);
            //shiftRepository.Update(shift);

        }
    }
}
