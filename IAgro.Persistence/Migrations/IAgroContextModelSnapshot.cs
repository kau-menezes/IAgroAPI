﻿// <auto-generated />
using System;
using IAgro.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IAgro.Persistence.Migrations
{
    [DbContext(typeof(IAgroContext))]
    partial class IAgroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IAgro.Domain.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("cnpj");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("IAgro.Domain.Models.CropDisease", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<DateTime>("DetectedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("detected_at");

                    b.Property<string>("Disease")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("disease");

                    b.Property<Guid>("FieldScanId")
                        .HasColumnType("uuid")
                        .HasColumnName("field_scan_id");

                    b.Property<Point>("LocationPoint")
                        .IsRequired()
                        .HasColumnType("geometry (Point, 4326)")
                        .HasColumnName("location_point");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("FieldScanId");

                    b.ToTable("crop_diseases", (string)null);
                });

            modelBuilder.Entity("IAgro.Domain.Models.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("code");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Nickname")
                        .HasColumnType("varchar(35)")
                        .HasColumnName("nickname");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("devices", (string)null);
                });

            modelBuilder.Entity("IAgro.Domain.Models.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<double>("Area")
                        .HasColumnType("double precision")
                        .HasColumnName("area");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<string>("Crop")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasColumnName("crop");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<MultiPoint>("LocationPoints")
                        .IsRequired()
                        .HasColumnType("geometry (MultiPoint, 4326)")
                        .HasColumnName("location_points");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasColumnName("nickname");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("fields", (string)null);
                });

            modelBuilder.Entity("IAgro.Domain.Models.FieldScan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uuid")
                        .HasColumnName("device_id");

                    b.Property<Guid>("FieldId")
                        .HasColumnType("uuid")
                        .HasColumnName("field_id");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("started_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("FieldId");

                    b.ToTable("field_scans", (string)null);
                });

            modelBuilder.Entity("IAgro.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<short>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0)
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("IAgro.Domain.Models.CropDisease", b =>
                {
                    b.HasOne("IAgro.Domain.Models.FieldScan", "FieldScan")
                        .WithMany("CropDiseases")
                        .HasForeignKey("FieldScanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FieldScan");
                });

            modelBuilder.Entity("IAgro.Domain.Models.Device", b =>
                {
                    b.HasOne("IAgro.Domain.Models.Company", "Company")
                        .WithMany("Devices")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("IAgro.Domain.Models.Field", b =>
                {
                    b.HasOne("IAgro.Domain.Models.Company", "Company")
                        .WithMany("Fields")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("IAgro.Domain.Models.FieldScan", b =>
                {
                    b.HasOne("IAgro.Domain.Models.Device", "Device")
                        .WithMany("FieldScans")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IAgro.Domain.Models.Field", "Field")
                        .WithMany("FieldScans")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Field");
                });

            modelBuilder.Entity("IAgro.Domain.Models.User", b =>
                {
                    b.HasOne("IAgro.Domain.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("IAgro.Domain.Models.Company", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("Fields");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("IAgro.Domain.Models.Device", b =>
                {
                    b.Navigation("FieldScans");
                });

            modelBuilder.Entity("IAgro.Domain.Models.Field", b =>
                {
                    b.Navigation("FieldScans");
                });

            modelBuilder.Entity("IAgro.Domain.Models.FieldScan", b =>
                {
                    b.Navigation("CropDiseases");
                });
#pragma warning restore 612, 618
        }
    }
}
