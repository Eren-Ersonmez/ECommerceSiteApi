using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35c0ad04-bbf2-4abb-b21a-3c2fa5b7c00d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("57da976e-65a3-411a-82c7-07faee89eeee"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("58ec3d8c-f66a-4dec-8e67-e3debd4920ba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("77a7eabf-7480-464c-9de6-630168fdaae8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c21b934b-0889-4f14-bd2f-dfd24a95331f"));

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CategoryId",
                table: "Brands",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
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

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("35c0ad04-bbf2-4abb-b21a-3c2fa5b7c00d"), new DateTime(2024, 9, 10, 15, 57, 24, 404, DateTimeKind.Local).AddTicks(535), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57da976e-65a3-411a-82c7-07faee89eeee"), new DateTime(2024, 9, 10, 15, 57, 24, 404, DateTimeKind.Local).AddTicks(551), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("58ec3d8c-f66a-4dec-8e67-e3debd4920ba"), new DateTime(2024, 9, 10, 15, 57, 24, 404, DateTimeKind.Local).AddTicks(533), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("77a7eabf-7480-464c-9de6-630168fdaae8"), new DateTime(2024, 9, 10, 15, 57, 24, 404, DateTimeKind.Local).AddTicks(482), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c21b934b-0889-4f14-bd2f-dfd24a95331f"), new DateTime(2024, 9, 10, 15, 57, 24, 404, DateTimeKind.Local).AddTicks(550), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
