using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class PasswordHashAndSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16d1d211-f90d-4be0-acc0-6126931e8772");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51c7b80c-1d85-4ac8-8691-5288e6653fc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96fa7f57-7b44-4125-96e1-44bfea3f9ff3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a371df4a-6910-48de-ad55-5ec5a10d56ca");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "532ff8ab-06bc-4329-9c7f-8a4fc4836e98", "Client" },
                    { "83abcde1-9040-478d-9298-24983178d1a9", "RegularUser" },
                    { "0227c673-327b-4341-92ea-8e23be5fcca8", "Trainer" },
                    { "87f64471-d488-4951-bf66-36985a48fbb8", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0227c673-327b-4341-92ea-8e23be5fcca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "532ff8ab-06bc-4329-9c7f-8a4fc4836e98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83abcde1-9040-478d-9298-24983178d1a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87f64471-d488-4951-bf66-36985a48fbb8");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "96fa7f57-7b44-4125-96e1-44bfea3f9ff3", "Client" },
                    { "16d1d211-f90d-4be0-acc0-6126931e8772", "RegularUser" },
                    { "51c7b80c-1d85-4ac8-8691-5288e6653fc9", "Trainer" },
                    { "a371df4a-6910-48de-ad55-5ec5a10d56ca", "ArticleWriter" }
                });
        }
    }
}
