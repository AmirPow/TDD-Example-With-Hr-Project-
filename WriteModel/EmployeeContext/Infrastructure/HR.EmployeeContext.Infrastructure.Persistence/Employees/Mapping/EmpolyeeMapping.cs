using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.EmployeeContext.Domain.Employees;
using HR.Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees.Mapping
{
    public class EmployeeMapping : EntityMappingBase<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            Initial(builder);
            builder.Property(a => a.NationalCode)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();
       
        }
    }
}