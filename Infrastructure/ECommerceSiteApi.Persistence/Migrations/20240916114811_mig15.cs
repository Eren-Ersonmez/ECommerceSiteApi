using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ibans_AspNetUsers_ApplicationUserId1",
                table: "Ibans");

            migrationBuilder.DropIndex(
                name: "IX_Ibans_ApplicationUserId1",
                table: "Ibans");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5bba441b-9d52-4457-b3b5-05a1b6c27c80"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("db0ff65c-0e7f-4e0a-bf8e-b2084552f47a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e08b6d7f-06b8-4f0f-96d3-2898f877873a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e56ccdf0-6d2b-43b8-b0a5-a9d10481df72"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe503ee5-4730-41ba-b2ca-5d57295d7774"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Ibans");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Ibans",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.CreateIndex(
                name: "IX_Ibans_ApplicationUserId",
                table: "Ibans",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ibans_AspNetUsers_ApplicationUserId",
                table: "Ibans",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ibans_AspNetUsers_ApplicationUserId",
                table: "Ibans");

            migrationBuilder.DropIndex(
                name: "IX_Ibans_ApplicationUserId",
                table: "Ibans");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "Ibans",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Ibans",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5bba441b-9d52-4457-b3b5-05a1b6c27c80"), new DateTime(2024, 9, 15, 21, 31, 20, 181, DateTimeKind.Local).AddTicks(8045), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db0ff65c-0e7f-4e0a-bf8e-b2084552f47a"), new DateTime(2024, 9, 15, 21, 31, 20, 181, DateTimeKind.Local).AddTicks(7985), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e08b6d7f-06b8-4f0f-96d3-2898f877873a"), new DateTime(2024, 9, 15, 21, 31, 20, 181, DateTimeKind.Local).AddTicks(8046), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e56ccdf0-6d2b-43b8-b0a5-a9d10481df72"), new DateTime(2024, 9, 15, 21, 31, 20, 181, DateTimeKind.Local).AddTicks(8043), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe503ee5-4730-41ba-b2ca-5d57295d7774"), new DateTime(2024, 9, 15, 21, 31, 20, 181, DateTimeKind.Local).AddTicks(8061), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ibans_ApplicationUserId1",
                table: "Ibans",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ibans_AspNetUsers_ApplicationUserId1",
                table: "Ibans",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
