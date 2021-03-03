using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class FirstNameIsRequiredException: DomainException
   {
       public override string Message => Resource.Resource.FirstNameIsRequiredException;
   }
}
