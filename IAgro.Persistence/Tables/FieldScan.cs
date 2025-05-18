using IAgro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IAgro.Persistence.Tables;

public static class FieldScanTableExtensions
{
    public static void ConfigureFieldScanTable(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FieldScan>(entity =>
        {
            entity.ToTable("field_scans");

            entity.ConfigureBaseTableProps();

            entity.Property(e => e.FieldId)
                .HasColumnName("field_id")
                .IsRequired();
            entity.HasOne(e => e.Field)
                .WithMany(f => f.FieldScans)
                .HasForeignKey(e => e.FieldId);
        });
    }
}