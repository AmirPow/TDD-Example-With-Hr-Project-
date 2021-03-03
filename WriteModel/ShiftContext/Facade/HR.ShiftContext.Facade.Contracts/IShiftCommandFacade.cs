using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Core.Facade;
using HR.ShiftContext.ApplicationService.Contracts.Shifts;

namespace HR.ShiftContext.Facade.Contracts
{
    public interface IShiftCommandFacade
    {
        void ShiftCreate(ShiftCreateCommand command);
        void ShiftUpdate(ShiftUpdateCommand command);
        void ShiftRemove(ShiftRemoveCommand command);
        void ShiftSegmentAdd(ShiftSegmentAddCommand command);
        void ShiftSegmentRemove(ShiftSegmentRemoveCommand command);
        void ShiftSegmentUpdate(ShiftSegmentUpdateCommand command);
    }
}
