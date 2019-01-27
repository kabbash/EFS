using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddSubFolderNameToArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c478e23e-b1f5-4f43-90da-e0a3036a3efe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd07ee20-c827-4513-bab1-041f54469eab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3a41851-4edd-4175-a70b-e281a998510d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eda5c1de-fa0c-4bc5-80e2-bc0b3ef79e5f");

            migrationBuilder.AddColumn<string>(
                name: "SubFolderName",
                table: "Articles",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SubFolderName",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 24, 11, 51, 21, 917, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 24, 11, 51, 21, 922, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "c478e23e-b1f5-4f43-90da-e0a3036a3efe", "Client" },
                    { "eda5c1de-fa0c-4bc5-80e2-bc0b3ef79e5f", "RegularUser" },
                    { "dd07ee20-c827-4513-bab1-041f54469eab", "Trainer" },
                    { "e3a41851-4edd-4175-a70b-e281a998510d", "ArticleWriter" }
                });
        }
    }
}
