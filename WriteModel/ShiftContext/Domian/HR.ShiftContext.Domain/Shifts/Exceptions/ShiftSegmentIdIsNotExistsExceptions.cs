using HR.Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.Shifts.Exceptions
{
    public class ShiftSegmentIdIsNotExistsExceptions : DomainException
    {
        public override string Message => ExceptionResource.ShiftSegmentIdIsNotExistsExceptions;
    }
}
