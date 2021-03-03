using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class PersonalCodeMustBeDigitException: DomainException
   {
       public override string Message => Resource.Resource.PersonalCodeMustBeDigitException;
   }
}
