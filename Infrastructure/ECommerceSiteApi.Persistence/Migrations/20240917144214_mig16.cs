using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("30602e13-2465-4883-a3b8-09734eb677b7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("41a98ed4-f610-415f-ad86-aafa448e2d81"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("96ffd376-9080-4aa2-ad79-a94cadf12452"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f8d90e7a-1136-4533-aab5-db3bff13c7a0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fbd2ecc0-b63a-4883-b942-c3a37ecd0e29"));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1e2215f6-26a9-498d-a7e0-a5583e07ac7a"), new DateTime(2024, 9, 17, 17, 42, 13, 764, DateTimeKind.Local).AddTicks(9395), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("255e1bf6-236e-4e0d-b209-89f5a7434738"), new DateTime(2024, 9, 17, 17, 42, 13, 764, DateTimeKind.Local).AddTicks(9390), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4760d58d-4dad-47f3-951c-4b6db64ea2bc"), new DateTime(2024, 9, 17, 17, 42, 13, 764, DateTimeKind.Local).AddTicks(9330), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc8bfde5-a6b5-4984-9e34-625248761512"), new DateTime(2024, 9, 17, 17, 42, 13, 764, DateTimeKind.Local).AddTicks(9393), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f7b9a360-5e5f-47e4-9fe1-3eca5a8d5a1e"), new DateTime(2024, 9, 17, 17, 42, 13, 764, DateTimeKind.Local).AddTicks(9392), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1e2215f6-26a9-498d-a7e0-a5583e07ac7a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("255e1bf6-236e-4e0d-b209-89f5a7434738"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4760d58d-4dad-47f3-951c-4b6db64ea2bc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dc8bfde5-a6b5-4984-9e34-625248761512"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f7b9a360-5e5f-47e4-9fe1-3eca5a8d5a1e"));

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("30602e13-2465-4883-a3b8-09734eb677b7"), new DateTime(2024, 9, 16, 14, 48, 11, 554, DateTimeKind.Local).AddTicks(5985), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("41a98ed4-f610-415f-ad86-aafa448e2d81"), new DateTime(2024, 9, 16, 14, 48, 11, 554, DateTimeKind.Local).AddTicks(5988), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("96ffd376-9080-4aa2-ad79-a94cadf12452"), new DateTime(2024, 9, 16, 14, 48, 11, 554, DateTimeKind.Local).AddTicks(5987), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8d90e7a-1136-4533-aab5-db3bff13c7a0"), new DateTime(2024, 9, 16, 14, 48, 11, 554, DateTimeKind.Local).AddTicks(5984), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fbd2ecc0-b63a-4883-b942-c3a37ecd0e29"), new DateTime(2024, 9, 16, 14, 48, 11, 554, DateTimeKind.Local).AddTicks(5891), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
