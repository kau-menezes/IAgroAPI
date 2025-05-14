using IAgro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IAgro.Persistence.Tables;

public static class CropDataTableExtensions
{
    public static void ConfigureCropDataTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<CropData>(entity =>
        {
            entity.ToTable("crops_data");

            entity.ConfigureBaseTableProps();

            entity.Property(cd => cd.CompanyId)
                .HasColumnName("company_id")
                .IsRequired();
            entity.HasOne(cd => cd.Company)
                .WithMany(c => c.CropsData)
                .HasForeignKey(cd => cd.CompanyId);
            
            entity.Property(cd => cd.DiseaseCoords)
                .HasColumnName("disease_coords")
                .HasColumnType("text[]");
        });
}