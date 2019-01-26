using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddProductsRejectReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "363965f3-002e-4b7e-ba29-35e6ff05e365");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46abd3c0-815b-4bdb-af31-f80671832df2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "655bd8e2-4fc4-42cd-9aa3-5d6b80034612");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7431fd78-5e03-47f3-95ae-2ddb18f065a7");

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 18, 15, 33, 55, 109, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 18, 15, 33, 55, 112, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "782cc0a6-89f9-4b9d-86c6-9314569f9ce1", "Client" },
                    { "235fdede-204d-46c6-b2a3-9c6b0f775848", "RegularUser" },
                    { "e1b207e2-ff11-4756-bbfa-4698bc52b734", "Trainer" },
                    { "32fc0130-ba49-478c-a743-9751396b7f81", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235fdede-204d-46c6-b2a3-9c6b0f775848");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32fc0130-ba49-478c-a743-9751396b7f81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "782cc0a6-89f9-4b9d-86c6-9314569f9ce1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1b207e2-ff11-4756-bbfa-4698bc52b734");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 13, 14, 25, 9, 630, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 13, 14, 25, 9, 663, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "46abd3c0-815b-4bdb-af31-f80671832df2", "Client" },
                    { "363965f3-002e-4b7e-ba29-35e6ff05e365", "RegularUser" },
                    { "7431fd78-5e03-47f3-95ae-2ddb18f065a7", "Trainer" },
                    { "655bd8e2-4fc4-42cd-9aa3-5d6b80034612", "ArticleWriter" }
                });
        }
    }
}
