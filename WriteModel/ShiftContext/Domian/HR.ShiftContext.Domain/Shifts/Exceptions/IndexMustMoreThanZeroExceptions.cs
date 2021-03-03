using HR.Framework.Domain;
using HR.ShiftContext.Resources;

namespace HR.ShiftContext.Domain.Shifts.Exceptions
{
    public class IndexMustMoreThanZeroExceptions : DomainException
    {
        public override string Message => ExceptionResource.IndexMustMoreThanZeroExceptions;
    }
}
