using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAgro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeviceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "devices",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "company_id",
                table: "devices",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_devices_company_id",
                table: "devices",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "FK_devices_companies_company_id",
                table: "devices",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_devices_companies_company_id",
                table: "devices");

            migrationBuilder.DropIndex(
                name: "IX_devices_company_id",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "code",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "company_id",
                table: "devices");
        }
    }
}
