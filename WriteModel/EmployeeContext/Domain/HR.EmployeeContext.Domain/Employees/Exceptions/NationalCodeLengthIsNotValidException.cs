using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class NationalCodeLengthIsNotValidException: DomainException
   {
       public override string Message => Resource.Resource.NationalCodeLengthIsNotValidException;
   }
}
