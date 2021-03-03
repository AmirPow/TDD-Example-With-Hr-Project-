using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class EmployeeIdOfContractIsNotExist : DomainException
   {
       public override string Message => Resource.Resource.EmployeeIdOfContractIsNotExist;
   }
}
