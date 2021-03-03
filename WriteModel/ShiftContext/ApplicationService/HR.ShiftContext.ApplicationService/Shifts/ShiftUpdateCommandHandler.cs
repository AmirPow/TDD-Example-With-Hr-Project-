using HR.Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contracts.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftUpdateCommandHandler : ICommandHandler<ShiftUpdateCommand>
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftUpdateCommandHandler(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public void Execute(ShiftUpdateCommand command)
        {
            var shift = shiftRepository.GetShift(command.ShiftId);

            shift.SetTitle(command.ShiftTitle);

            shiftRepository.Update(shift);

        }
    }
}

