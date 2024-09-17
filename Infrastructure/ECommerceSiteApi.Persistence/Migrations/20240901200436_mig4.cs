using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceSiteApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endpoints_Menus_MenuId",
                table: "Endpoints");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("016d95c1-da2b-4433-825a-2d2b1d4bafa7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2e8641f6-7e1f-4162-87c4-e9274b35ab31"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45584ea8-06aa-4867-bbad-2e20eef2bffe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("853552c3-3efa-4f7e-8d3e-1b3c83de70f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b0a6f1b0-3f51-4c0c-af0f-631e49150816"));

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId1",
                table: "Endpoints",
                type: "uniqueidentifier",
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

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_MenuId1",
                table: "Endpoints",
                column: "MenuId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoints_Menus_MenuId",
                table: "Endpoints",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoints_Menus_MenuId1",
                table: "Endpoints",
                column: "MenuId1",
                principalTable: "Menus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endpoints_Menus_MenuId",
                table: "Endpoints");

            migrationBuilder.DropForeignKey(
                name: "FK_Endpoints_Menus_MenuId1",
                table: "Endpoints");

            migrationBuilder.DropIndex(
                name: "IX_Endpoints_MenuId1",
                table: "Endpoints");

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
                name: "MenuId1",
                table: "Endpoints");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("016d95c1-da2b-4433-825a-2d2b1d4bafa7"), new DateTime(2024, 9, 1, 12, 24, 10, 435, DateTimeKind.Local).AddTicks(9926), "Makyaj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e8641f6-7e1f-4162-87c4-e9274b35ab31"), new DateTime(2024, 9, 1, 12, 24, 10, 435, DateTimeKind.Local).AddTicks(9928), "Buzdolabı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("45584ea8-06aa-4867-bbad-2e20eef2bffe"), new DateTime(2024, 9, 1, 12, 24, 10, 435, DateTimeKind.Local).AddTicks(9878), "Bilgisayar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("853552c3-3efa-4f7e-8d3e-1b3c83de70f3"), new DateTime(2024, 9, 1, 12, 24, 10, 435, DateTimeKind.Local).AddTicks(9952), "Çamaşır Makinesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0a6f1b0-3f51-4c0c-af0f-631e49150816"), new DateTime(2024, 9, 1, 12, 24, 10, 435, DateTimeKind.Local).AddTicks(9925), "Ütü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoints_Menus_MenuId",
                table: "Endpoints",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
