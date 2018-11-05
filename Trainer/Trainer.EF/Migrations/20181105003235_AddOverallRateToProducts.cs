using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddOverallRateToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cfc83f8-9682-4e26-8682-a3bd8055a0c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f4d24f9-e67e-461d-a9f2-61c7603ce619");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cab84034-ba13-4d47-b7b0-d6973e30ce84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fda1869e-f714-47a8-a456-77def1d1fa38");

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "3ea04402-1b6a-4239-bde4-ef514521d7b8", "Client" },
                    { "24375a82-6a48-4dc5-98cc-ffc4d9930e92", "ProductOwner" },
                    { "36414a7f-ef7f-485e-9ccb-ea884193b06e", "RegularUser" },
                    { "e1b95863-759a-434e-b9dc-2f3bd70e343b", "Trainer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24375a82-6a48-4dc5-98cc-ffc4d9930e92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36414a7f-ef7f-485e-9ccb-ea884193b06e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ea04402-1b6a-4239-bde4-ef514521d7b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1b95863-759a-434e-b9dc-2f3bd70e343b");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "9f4d24f9-e67e-461d-a9f2-61c7603ce619", "Client" },
                    { "fda1869e-f714-47a8-a456-77def1d1fa38", "ProductOwner" },
                    { "cab84034-ba13-4d47-b7b0-d6973e30ce84", "RegularUser" },
                    { "5cfc83f8-9682-4e26-8682-a3bd8055a0c1", "Trainer" }
                });
        }
    }
}
