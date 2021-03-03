using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class NationalCodeIsRequiredException: DomainException
   {
       public override string Message => Resource.Resource.NationalCodeIsRequiredException;
   }
}
