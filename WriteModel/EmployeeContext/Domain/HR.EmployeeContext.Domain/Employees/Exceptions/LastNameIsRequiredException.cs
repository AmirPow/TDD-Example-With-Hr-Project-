using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class LastNameIsRequiredException: DomainException
   {
       public override string Message => Resource.Resource.LastNameIsRequiredException;
   }
}
