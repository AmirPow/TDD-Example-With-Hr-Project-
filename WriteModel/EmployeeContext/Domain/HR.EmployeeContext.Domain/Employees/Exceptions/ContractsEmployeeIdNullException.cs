using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class ContractsEmployeeIdNullException : DomainException
   {
       public override string Message => Resource.Resource.ContractsEmployeeIdNullException;
   }
}
