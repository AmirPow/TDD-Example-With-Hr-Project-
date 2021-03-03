using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class PersonalCodeIsRequiredException: DomainException
   {
       public override string Message => Resource.Resource.PersonalCodeIsRequiredException;
   }
}
