using HR.Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.Shifts.Exceptions
{
    public class ShiftSegmentIndexCanNotBeDuplicateExceptions : DomainException
    {
        public override string Message => ExceptionResource.ShiftSegmentIndexCanNotBeDuplicateExceptions;
    }
}
