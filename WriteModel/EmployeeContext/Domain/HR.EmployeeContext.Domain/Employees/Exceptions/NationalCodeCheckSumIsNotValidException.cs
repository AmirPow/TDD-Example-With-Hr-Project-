using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class NationalCodeCheckSumIsNotValidException: DomainException
   {
       public override string Message => Resource.Resource.NationalCodeCheckSumIsNotValidException;
   }
}
