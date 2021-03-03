using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class NationalCodeMustBeUniqueException: DomainException
   {
       public override string Message => Resource.Resource.NationalCodeMustBeUniqueException;
   }
}
