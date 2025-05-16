using IAgro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IAgro.Persistence.Tables;
public static class FieldTableExtensions
{
    public static void ConfigureFieldTable(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Field>(entity =>
        {
            entity.ToTable("Fields");

            entity.ConfigureBaseTableProps();

            entity.Property(f => f.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(35)")
                .IsRequired();
            entity.HasIndex(f => f.Name)
                .IsUnique();

            entity.Property(f => f.Area)
                .HasColumnName("area")
                .HasColumnType("double")
                .IsRequired();
            
            entity.Property(f => f.Coords)
                .HasColumnName("coords")
                .HasColumnType("double[]")
                .IsRequired();
            
            entity.Property(f => f.Crop)
                .HasColumnName("crop")
                .HasColumnType("varchar(35)")
                .IsRequired();
            
            entity.Property(f => f.State)
                .HasColumnName("state")
                .HasColumnType("varchar(35)")
                .IsRequired();
        });
    }
}