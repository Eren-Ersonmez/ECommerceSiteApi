using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("184d2c8f-90d5-44d2-9a03-45a56070b8e4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91b92396-2bda-40e4-bf43-292956265f1a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9cf2f489-e183-4545-9019-1e399edcf4ac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ac840f0c-871b-427c-a6dc-9514bfadf8f8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e2ae81a3-a3d4-400c-b56f-d601c8ebdd53"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("74e0d027-13e4-4f90-979e-dc0db6207bb3"), new DateTime(2024, 9, 2, 16, 58, 10, 408, DateTimeKind.Local).AddTicks(8655), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a94d6e6b-e939-46be-9db6-1da0c4c2199f"), new DateTime(2024, 9, 2, 16, 58, 10, 408, DateTimeKind.Local).AddTicks(8635), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8bfca95-f1f9-49d9-b9b8-d1c3d097eca9"), new DateTime(2024, 9, 2, 16, 58, 10, 408, DateTimeKind.Local).AddTicks(8656), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d326f81f-72c7-479c-bc26-fd78fc748f30"), new DateTime(2024, 9, 2, 16, 58, 10, 408, DateTimeKind.Local).AddTicks(8637), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d6be0671-9784-44b2-b439-d473d5663b5c"), new DateTime(2024, 9, 2, 16, 58, 10, 408, DateTimeKind.Local).AddTicks(8596), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74e0d027-13e4-4f90-979e-dc0db6207bb3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a94d6e6b-e939-46be-9db6-1da0c4c2199f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c8bfca95-f1f9-49d9-b9b8-d1c3d097eca9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d326f81f-72c7-479c-bc26-fd78fc748f30"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6be0671-9784-44b2-b439-d473d5663b5c"));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("184d2c8f-90d5-44d2-9a03-45a56070b8e4"), new DateTime(2024, 9, 1, 23, 4, 35, 752, DateTimeKind.Local).AddTicks(9027), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91b92396-2bda-40e4-bf43-292956265f1a"), new DateTime(2024, 9, 1, 23, 4, 35, 752, DateTimeKind.Local).AddTicks(9025), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9cf2f489-e183-4545-9019-1e399edcf4ac"), new DateTime(2024, 9, 1, 23, 4, 35, 752, DateTimeKind.Local).AddTicks(9036), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ac840f0c-871b-427c-a6dc-9514bfadf8f8"), new DateTime(2024, 9, 1, 23, 4, 35, 752, DateTimeKind.Local).AddTicks(8983), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2ae81a3-a3d4-400c-b56f-d601c8ebdd53"), new DateTime(2024, 9, 1, 23, 4, 35, 752, DateTimeKind.Local).AddTicks(9023), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
