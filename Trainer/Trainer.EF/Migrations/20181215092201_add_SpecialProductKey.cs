using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class add_SpecialProductKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a3d5ce7-e06a-4092-8089-bb307bd8a8f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "662f74fe-9de9-4b4c-b778-ad2227e09dc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b82395de-efa9-4569-800d-144c6f43baca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb404ba2-13c9-4c54-ac59-b7b15f1e359c");

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecial",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0f05de72-f93c-4290-b070-a510a6dd9e59", "Client" },
                    { "e542b29c-89af-4d12-95c4-0614aa698d12", "RegularUser" },
                    { "cc4d4a9c-3e3b-4da2-ae9a-4a94cac04320", "Trainer" },
                    { "d1e1fa1b-af56-4461-8c43-9f6d7916be40", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f05de72-f93c-4290-b070-a510a6dd9e59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc4d4a9c-3e3b-4da2-ae9a-4a94cac04320");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1e1fa1b-af56-4461-8c43-9f6d7916be40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e542b29c-89af-4d12-95c4-0614aa698d12");

            migrationBuilder.DropColumn(
                name: "IsSpecial",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "662f74fe-9de9-4b4c-b778-ad2227e09dc5", "Client" },
                    { "1a3d5ce7-e06a-4092-8089-bb307bd8a8f4", "RegularUser" },
                    { "fb404ba2-13c9-4c54-ac59-b7b15f1e359c", "Trainer" },
                    { "b82395de-efa9-4569-800d-144c6f43baca", "ArticleWriter" }
                });
        }
    }
}
