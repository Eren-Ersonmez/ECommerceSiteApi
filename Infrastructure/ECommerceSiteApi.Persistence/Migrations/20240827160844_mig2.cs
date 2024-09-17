using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0dae7362-5acb-458b-84be-c3838018a306"), new DateTime(2024, 8, 27, 19, 8, 44, 23, DateTimeKind.Local).AddTicks(6173), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b92efc0-f570-499f-8137-f3ccf971e574"), new DateTime(2024, 8, 27, 19, 8, 44, 23, DateTimeKind.Local).AddTicks(6215), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("204c9225-809f-445b-9eec-e1b5fc3cdea4"), new DateTime(2024, 8, 27, 19, 8, 44, 23, DateTimeKind.Local).AddTicks(6214), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5770e463-80c9-4fc4-ae35-7d5f869d4f73"), new DateTime(2024, 8, 27, 19, 8, 44, 23, DateTimeKind.Local).AddTicks(6227), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8f25e8f-b6d2-45ea-b534-9c1570ddd651"), new DateTime(2024, 8, 27, 19, 8, 44, 23, DateTimeKind.Local).AddTicks(6212), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0dae7362-5acb-458b-84be-c3838018a306"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1b92efc0-f570-499f-8137-f3ccf971e574"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("204c9225-809f-445b-9eec-e1b5fc3cdea4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5770e463-80c9-4fc4-ae35-7d5f869d4f73"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f8f25e8f-b6d2-45ea-b534-9c1570ddd651"));
        }
    }
}
