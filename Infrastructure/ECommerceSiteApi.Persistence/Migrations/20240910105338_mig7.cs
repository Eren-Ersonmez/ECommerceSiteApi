using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5175fd22-198e-464c-9026-6e863fce4e36"), new DateTime(2024, 9, 10, 13, 53, 38, 356, DateTimeKind.Local).AddTicks(9192), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5677c423-66dd-420d-951e-dba5b8ce8e21"), new DateTime(2024, 9, 10, 13, 53, 38, 356, DateTimeKind.Local).AddTicks(9206), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8193f620-655f-4012-a5ee-158ad0bb739f"), new DateTime(2024, 9, 10, 13, 53, 38, 356, DateTimeKind.Local).AddTicks(9190), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a295d121-6bac-4dde-be8f-0ffc812fc028"), new DateTime(2024, 9, 10, 13, 53, 38, 356, DateTimeKind.Local).AddTicks(9159), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("be6a13c1-f1a4-4db0-99ee-5ad0a36dc202"), new DateTime(2024, 9, 10, 13, 53, 38, 356, DateTimeKind.Local).AddTicks(9188), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5175fd22-198e-464c-9026-6e863fce4e36"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5677c423-66dd-420d-951e-dba5b8ce8e21"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8193f620-655f-4012-a5ee-158ad0bb739f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a295d121-6bac-4dde-be8f-0ffc812fc028"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("be6a13c1-f1a4-4db0-99ee-5ad0a36dc202"));
        }
    }
}
