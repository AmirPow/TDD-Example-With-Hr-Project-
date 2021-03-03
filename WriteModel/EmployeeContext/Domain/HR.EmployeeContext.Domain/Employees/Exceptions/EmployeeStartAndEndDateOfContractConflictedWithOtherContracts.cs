using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class EmployeeStartAndEndDateOfContractConflictedWithOtherContracts : DomainException
   {
       public override string Message => Resource.Resource.EmployeeStartAndEndDateOfContractConflictedWithOtherContracts;
   }
}
