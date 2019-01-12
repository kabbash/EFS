using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddRejectionReasonInArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08dc5a08-68e0-46ba-9122-46e633294314");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "819991a4-5ab7-47b6-b7ae-12278cec1422");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dd8ea17-a222-4d5f-87c1-9e049fbc59a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3ad873c-136b-4dc1-bf00-7b230e74cd52");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Articles",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "Articles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 12, 11, 34, 24, 9, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 12, 11, 34, 24, 41, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "57ff8bc7-860e-4436-b50d-1b1052bab4e0", "Client" },
                    { "ff9eecba-da67-4049-92e4-e9253f74bcaf", "RegularUser" },
                    { "694b82c4-21d0-4406-a010-984562d47631", "Trainer" },
                    { "c6cb885e-a9f1-4b78-97f1-3fec72aa2982", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57ff8bc7-860e-4436-b50d-1b1052bab4e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "694b82c4-21d0-4406-a010-984562d47631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6cb885e-a9f1-4b78-97f1-3fec72aa2982");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff9eecba-da67-4049-92e4-e9253f74bcaf");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "Articles");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Articles",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 6, 15, 16, 7, 882, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 6, 15, 16, 7, 884, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "819991a4-5ab7-47b6-b7ae-12278cec1422", "Client" },
                    { "f3ad873c-136b-4dc1-bf00-7b230e74cd52", "RegularUser" },
                    { "08dc5a08-68e0-46ba-9122-46e633294314", "Trainer" },
                    { "8dd8ea17-a222-4d5f-87c1-9e049fbc59a8", "ArticleWriter" }
                });
        }
    }
}
