using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class IOEmployeeIdNullException : DomainException
   {
       public override string Message => Resource.Resource.IOEmployeeIdNullException;
   }
}
