using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class RemoveProdDateAndMakeIsActiveNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ProdDate",
                table: "Products");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 19, 22, 9, 59, 527, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 19, 22, 9, 59, 530, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "4f288805-d790-42e4-9fe4-1d88c901f5fc", "Client" },
                    { "6a354086-d105-48ef-976e-587b8711e475", "RegularUser" },
                    { "de3c874a-ea59-4a51-bf5e-f6db18ebd398", "Trainer" },
                    { "52338c88-8e26-4dc6-9890-bc0e13df06ba", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f288805-d790-42e4-9fe4-1d88c901f5fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52338c88-8e26-4dc6-9890-bc0e13df06ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a354086-d105-48ef-976e-587b8711e475");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de3c874a-ea59-4a51-bf5e-f6db18ebd398");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProdDate",
                table: "Products",
                type: "date",
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
    }
}
