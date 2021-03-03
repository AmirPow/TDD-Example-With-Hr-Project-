using System.Data;
using HR.Framework.Persistence;
using HR.ShiftContext.Domain.Shifts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.ShiftContext.Infrastructure.Persistence.Shifts.Mapping
{
    public class ShiftSegmentMapping : EntityMappingBase<ShiftSegment>
    {
        public override void Configure(EntityTypeBuilder<ShiftSegment> builder)
        {
            Initial(builder);
            builder.Property(a=>a.ShiftId).
                HasColumnType(nameof(SqlDbType.UniqueIdentifier))
                .IsRequired();

            builder.Property(a => a.Index)
                .HasColumnType(nameof(SqlDbType.Int))
                .IsRequired();

            builder.Property(a => a.StartTime)
                .HasColumnType(nameof(SqlDbType.Time))
                .HasMaxLength(8)
                .IsRequired(); 

            builder.Property(a => a.EndTime)
                .HasColumnType(nameof(SqlDbType.Time))
                .HasMaxLength(8)
                .IsRequired();



            builder.HasOne<Shift>()
                .WithMany(a => a.ShiftSegments)
                .HasForeignKey(e => e.ShiftId)
                .HasConstraintName("FK_Shift_ShiftPeriods");
        }
    }
}
