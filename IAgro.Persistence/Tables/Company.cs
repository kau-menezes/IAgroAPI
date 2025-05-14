using IAgro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IAgro.Persistence.Tables;

public static class CompanyTableExtensions
{
    public static void ConfigureCompanyTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("companies");

            entity.ConfigureBaseTableProps();

            entity.HasMany(c => c.CropsData)
                .WithOne(cd => cd.Company)
                .HasForeignKey(cd => cd.CompanyId);
            
            entity.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(35)")
                .IsRequired();
            entity.HasIndex(c => c.Name)
                .IsUnique();
        });
}
