using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ApplicationUserProduct",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavoriteProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserProduct", x => new { x.ApplicationUsersId, x.FavoriteProductsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_Products_FavoriteProductsId",
                        column: x => x.FavoriteProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("46f2cd1a-d76b-4b02-a4c9-57c76b549aa5"), new DateTime(2024, 9, 14, 20, 1, 43, 383, DateTimeKind.Local).AddTicks(6468), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("50087bbe-8780-4875-b5bb-c38080840110"), new DateTime(2024, 9, 14, 20, 1, 43, 383, DateTimeKind.Local).AddTicks(6421), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7fa0f1e-09f4-47e3-89b5-464ab03930df"), new DateTime(2024, 9, 14, 20, 1, 43, 383, DateTimeKind.Local).AddTicks(6465), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9ff7729-9091-4e9d-b745-531f7e562c71"), new DateTime(2024, 9, 14, 20, 1, 43, 383, DateTimeKind.Local).AddTicks(6466), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e144d460-3925-48c6-b79d-a0aecd740dc7"), new DateTime(2024, 9, 14, 20, 1, 43, 383, DateTimeKind.Local).AddTicks(6480), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProduct_FavoriteProductsId",
                table: "ApplicationUserProduct",
                column: "FavoriteProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserProduct");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("46f2cd1a-d76b-4b02-a4c9-57c76b549aa5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("50087bbe-8780-4875-b5bb-c38080840110"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a7fa0f1e-09f4-47e3-89b5-464ab03930df"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a9ff7729-9091-4e9d-b745-531f7e562c71"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e144d460-3925-48c6-b79d-a0aecd740dc7"));

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
    }
}
