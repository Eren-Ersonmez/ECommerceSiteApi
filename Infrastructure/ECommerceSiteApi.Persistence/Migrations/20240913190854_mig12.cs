using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1434a870-8190-49d5-82ef-57860880f31a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("16003366-e3f2-45dc-88da-9f584f1dbbe0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5dfc37bf-719e-4761-adbf-05f0a68fea94"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a4ee0a31-d867-477b-8897-1d435220c70f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f3d1a3a7-69c0-4dd0-baaf-a72e9da3d2fa"));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("24f0e22e-c4c7-4d69-b310-c1c2e1e134a2"), new DateTime(2024, 9, 13, 22, 8, 54, 506, DateTimeKind.Local).AddTicks(1154), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("61e3e658-f678-41f6-8e8d-f26a68e398f7"), new DateTime(2024, 9, 13, 22, 8, 54, 506, DateTimeKind.Local).AddTicks(1141), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8252c2ba-d024-43be-bedb-0007a14f7741"), new DateTime(2024, 9, 13, 22, 8, 54, 506, DateTimeKind.Local).AddTicks(1158), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9a3a4b0-66ac-4a67-a29b-c0a15471aaf4"), new DateTime(2024, 9, 13, 22, 8, 54, 506, DateTimeKind.Local).AddTicks(1156), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6283593-abdb-49d7-8d7e-9dea6e648d37"), new DateTime(2024, 9, 13, 22, 8, 54, 506, DateTimeKind.Local).AddTicks(1098), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("24f0e22e-c4c7-4d69-b310-c1c2e1e134a2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("61e3e658-f678-41f6-8e8d-f26a68e398f7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8252c2ba-d024-43be-bedb-0007a14f7741"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a9a3a4b0-66ac-4a67-a29b-c0a15471aaf4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f6283593-abdb-49d7-8d7e-9dea6e648d37"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1434a870-8190-49d5-82ef-57860880f31a"), new DateTime(2024, 9, 13, 14, 16, 8, 504, DateTimeKind.Local).AddTicks(6875), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("16003366-e3f2-45dc-88da-9f584f1dbbe0"), new DateTime(2024, 9, 13, 14, 16, 8, 504, DateTimeKind.Local).AddTicks(6877), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5dfc37bf-719e-4761-adbf-05f0a68fea94"), new DateTime(2024, 9, 13, 14, 16, 8, 504, DateTimeKind.Local).AddTicks(6880), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4ee0a31-d867-477b-8897-1d435220c70f"), new DateTime(2024, 9, 13, 14, 16, 8, 504, DateTimeKind.Local).AddTicks(6833), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3d1a3a7-69c0-4dd0-baaf-a72e9da3d2fa"), new DateTime(2024, 9, 13, 14, 16, 8, 504, DateTimeKind.Local).AddTicks(6879), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
