using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class RemovePasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ccc079d-10a2-4a22-849f-70d52acf100a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84949def-e309-4844-a135-8c65af0ade43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca1e9300-f70a-4cd6-9e5a-9f5a72218623");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e71da101-68f6-4d85-b2ad-ef30ae34d1a2");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "84949def-e309-4844-a135-8c65af0ade43", "Client" },
                    { "1ccc079d-10a2-4a22-849f-70d52acf100a", "RegularUser" },
                    { "e71da101-68f6-4d85-b2ad-ef30ae34d1a2", "Trainer" },
                    { "ca1e9300-f70a-4cd6-9e5a-9f5a72218623", "ArticleWriter" }
                });
        }
    }
}
