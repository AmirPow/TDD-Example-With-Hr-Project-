using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class EmployeeStartDateOfContractConflictedWithOtherContracts : DomainException
   {
       public override string Message => Resource.Resource.EmployeeStartDateOfContractConflictedWithOtherContracts;
   }
}
