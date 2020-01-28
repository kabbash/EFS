using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class ChangeIdsToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00ad2bd8-d9fb-45d0-9ff3-501fa504f4a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b50dc64-bc1b-4c3d-b498-0b83adf3e357");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "170f7e17-92d7-4b8b-ab72-3f9a8ef348f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86b78b14-612e-453e-883d-621b957199b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "a7c62486-4265-483d-9231-f60fdebf2d0a", "Client" },
                    { "0b8f61f4-7d5a-4b74-89ee-d0d11dc126e2", "ProductOwner" },
                    { "bfedd55d-46c3-4e06-b29d-00bdb18bab47", "RegularUser" },
                    { "36714f5a-e957-4876-83d9-873a590531dd", "Trainer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b8f61f4-7d5a-4b74-89ee-d0d11dc126e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36714f5a-e957-4876-83d9-873a590531dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7c62486-4265-483d-9231-f60fdebf2d0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfedd55d-46c3-4e06-b29d-00bdb18bab47");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "170f7e17-92d7-4b8b-ab72-3f9a8ef348f6", "Client" },
                    { "86b78b14-612e-453e-883d-621b957199b4", "ProductOwner" },
                    { "0b50dc64-bc1b-4c3d-b498-0b83adf3e357", "RegularUser" },
                    { "00ad2bd8-d9fb-45d0-9ff3-501fa504f4a9", "Trainer" }
                });
        }
    }
}
