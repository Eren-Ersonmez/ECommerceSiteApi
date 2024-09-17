using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("06266bbc-a37f-4e87-9069-47cf33a4e488"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("673c0f9e-c819-43aa-987b-cd32f3831f29"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6adbe85f-5f09-4247-846b-728f1a928db6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c9e6510b-b509-4f88-bd3d-35f4ea1426d0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f66f0837-29cf-4715-983c-e02f7da324fa"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("021a7391-1e36-4638-9bf1-1037cbc96958"), new DateTime(2024, 9, 11, 20, 41, 28, 681, DateTimeKind.Local).AddTicks(6606), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0b517246-8ad5-4ebd-8cb4-414f304e48b7"), new DateTime(2024, 9, 11, 20, 41, 28, 681, DateTimeKind.Local).AddTicks(6558), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("382a0e4e-9239-470c-a3e8-6f828c0c6301"), new DateTime(2024, 9, 11, 20, 41, 28, 681, DateTimeKind.Local).AddTicks(6601), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5d00aac-a754-4096-94e5-6407ecad6d31"), new DateTime(2024, 9, 11, 20, 41, 28, 681, DateTimeKind.Local).AddTicks(6604), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f37bd8eb-900f-4d1b-985d-7a1ef598d12f"), new DateTime(2024, 9, 11, 20, 41, 28, 681, DateTimeKind.Local).AddTicks(6603), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("021a7391-1e36-4638-9bf1-1037cbc96958"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b517246-8ad5-4ebd-8cb4-414f304e48b7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("382a0e4e-9239-470c-a3e8-6f828c0c6301"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5d00aac-a754-4096-94e5-6407ecad6d31"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f37bd8eb-900f-4d1b-985d-7a1ef598d12f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BrandId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("06266bbc-a37f-4e87-9069-47cf33a4e488"), new DateTime(2024, 9, 11, 20, 32, 42, 621, DateTimeKind.Local).AddTicks(3075), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("673c0f9e-c819-43aa-987b-cd32f3831f29"), new DateTime(2024, 9, 11, 20, 32, 42, 621, DateTimeKind.Local).AddTicks(3076), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6adbe85f-5f09-4247-846b-728f1a928db6"), new DateTime(2024, 9, 11, 20, 32, 42, 621, DateTimeKind.Local).AddTicks(3023), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9e6510b-b509-4f88-bd3d-35f4ea1426d0"), new DateTime(2024, 9, 11, 20, 32, 42, 621, DateTimeKind.Local).AddTicks(3078), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f66f0837-29cf-4715-983c-e02f7da324fa"), new DateTime(2024, 9, 11, 20, 32, 42, 621, DateTimeKind.Local).AddTicks(3073), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
