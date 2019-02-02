using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddFolderColToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f6a93d5-8769-4479-89cc-1ba7abc20189");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f6ee453-1696-48b8-949a-5650c848011c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b994d8a-039f-4157-be71-f03532674de5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ef2128e-77b5-4504-88ee-ef0af3cf9fb6");

            migrationBuilder.AddColumn<string>(
                name: "SubFolderName",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 1, 12, 40, 7, 2, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 1, 12, 40, 7, 6, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "244ad97b-a914-465a-926c-92df0c297bdc", "Client" },
                    { "010721d6-1678-4dcf-b73b-bebf465c72c6", "RegularUser" },
                    { "819f2549-7706-41df-8c8c-d455a360d310", "Trainer" },
                    { "01efeabe-5f77-4629-afeb-99d990577feb", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "010721d6-1678-4dcf-b73b-bebf465c72c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01efeabe-5f77-4629-afeb-99d990577feb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "244ad97b-a914-465a-926c-92df0c297bdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "819f2549-7706-41df-8c8c-d455a360d310");

            migrationBuilder.DropColumn(
                name: "SubFolderName",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 27, 5, 52, 37, 867, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 27, 5, 52, 37, 871, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "6ef2128e-77b5-4504-88ee-ef0af3cf9fb6", "Client" },
                    { "4f6ee453-1696-48b8-949a-5650c848011c", "RegularUser" },
                    { "5b994d8a-039f-4157-be71-f03532674de5", "Trainer" },
                    { "1f6a93d5-8769-4479-89cc-1ba7abc20189", "ArticleWriter" }
                });
        }
    }
}
