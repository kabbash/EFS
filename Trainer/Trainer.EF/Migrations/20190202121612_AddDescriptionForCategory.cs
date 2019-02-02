using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddDescriptionForCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products_Categories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 2, 12, 16, 9, 914, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 2, 12, 16, 9, 921, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "e5774e77-a2a8-465a-a842-625d37015919", "Client" },
                    { "0bb2fc24-ec5e-43aa-8fcc-8ea8800ae41d", "RegularUser" },
                    { "04a38259-cdfe-4f81-9b46-253cbd27ff3b", "Trainer" },
                    { "e3458c1f-c840-4050-ad1e-b5b48cecbf78", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04a38259-cdfe-4f81-9b46-253cbd27ff3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bb2fc24-ec5e-43aa-8fcc-8ea8800ae41d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3458c1f-c840-4050-ad1e-b5b48cecbf78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5774e77-a2a8-465a-a842-625d37015919");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products_Categories");

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
    }
}
