using System;
using HR.Framework.Core.ApplicationService;
using HR.ShiftContext.ApplicationService.Contracts.Shifts;
using HR.ShiftContext.Domain.Shifts;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.ShiftContext.ApplicationService.Shifts
{
    public class ShiftRemoveCommandHandler : ICommandHandler<ShiftRemoveCommand>
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftRemoveCommandHandler(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }
        public void Execute(ShiftRemoveCommand command)
        {
            var shift = shiftRepository.GetShift(command.ShiftId);
            
            shiftRepository.Remove(shift);

        }
    }
}

