using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddProductsToAspNetUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2677c844-24f9-43e5-9694-640c163624fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d09f971-9a1e-4d2d-bb65-6deaaf205f30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd325567-d68d-4ba5-8423-90230ddba9b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da2a8a88-fee2-4d52-b0f0-019863d33f76");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2677c844-24f9-43e5-9694-640c163624fe", "Client" },
                    { "da2a8a88-fee2-4d52-b0f0-019863d33f76", "RegularUser" },
                    { "bd325567-d68d-4ba5-8423-90230ddba9b7", "Trainer" },
                    { "9d09f971-9a1e-4d2d-bb65-6deaaf205f30", "ArticleWriter" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
