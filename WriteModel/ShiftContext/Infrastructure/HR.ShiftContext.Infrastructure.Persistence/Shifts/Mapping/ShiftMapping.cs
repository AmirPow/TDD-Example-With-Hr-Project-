using System.Data;
using HR.Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.ShiftContext.Infrastructure.Persistence.Shifts.Mapping
{
    public class ShiftMapping : EntityMappingBase<Shift>
    {
        public override void Configure(EntityTypeBuilder<Shift> builder)
        {
            Initial(builder);
            builder.Property(a => a.Title)
                .HasColumnType(nameof(SqlDbType.NVarChar))
                .HasMaxLength(350)
                .IsRequired(); 
        }
    }
}
