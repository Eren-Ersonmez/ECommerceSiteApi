using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ProductId",
                table: "ProductAttributes",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAttributes");

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
        }
    }
}
