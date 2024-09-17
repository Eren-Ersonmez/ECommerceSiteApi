using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_AspNetUsers_ApplicationUserId1",
                table: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_CreditCards_ApplicationUserId1",
                table: "CreditCards");

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

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "CreditCards");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "CreditCards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "IX_CreditCards_ApplicationUserId",
                table: "CreditCards",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_AspNetUsers_ApplicationUserId",
                table: "CreditCards",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_AspNetUsers_ApplicationUserId",
                table: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_CreditCards_ApplicationUserId",
                table: "CreditCards");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "CreditCards",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "CreditCards",
                type: "nvarchar(450)",
                nullable: true);

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
                name: "IX_CreditCards_ApplicationUserId1",
                table: "CreditCards",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_AspNetUsers_ApplicationUserId1",
                table: "CreditCards",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
