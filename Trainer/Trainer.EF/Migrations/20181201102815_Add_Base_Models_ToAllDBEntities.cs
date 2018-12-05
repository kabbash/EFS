using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class Add_Base_Models_ToAllDBEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18effbce-f41b-4dd7-a9e5-5c21d8f743e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "329a63df-98b4-4919-ad33-44ad05789e75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1990a1f-7eea-4fbe-bba3-ca5623fbbb8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3eb6e0b-1fa2-4cbb-a1b8-5d1525847b09");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Programs_Prices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Programs_Prices");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Programs_Prices");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Programs_Prices");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Programs_Images");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Programs_Images");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products_Images");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products_Images");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Programs_Images",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Programs_Images",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "EntityRatings",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "EntityRatings",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients_Images",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Clients_Images",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1f684f9d-fbdc-4090-a3bc-550832e9c2a1", "Client" },
                    { "b10ad127-8580-4517-ab01-129cac89adc1", "RegularUser" },
                    { "c90f41c8-2503-44ed-8ffa-d0b383010da5", "Trainer" },
                    { "345a50c7-4b52-4552-b955-63c8a8ab86f0", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f684f9d-fbdc-4090-a3bc-550832e9c2a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "345a50c7-4b52-4552-b955-63c8a8ab86f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b10ad127-8580-4517-ab01-129cac89adc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c90f41c8-2503-44ed-8ffa-d0b383010da5");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Clients_Images");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Programs_Images",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Programs_Images",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "EntityRatings",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "EntityRatings",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Clients_Images",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Programs_Prices",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Programs_Prices",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Programs_Prices",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Programs_Prices",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Programs_Images",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Programs_Images",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products_Images",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Products_Images",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "329a63df-98b4-4919-ad33-44ad05789e75", "Client" },
                    { "b3eb6e0b-1fa2-4cbb-a1b8-5d1525847b09", "RegularUser" },
                    { "18effbce-f41b-4dd7-a9e5-5c21d8f743e5", "Trainer" },
                    { "a1990a1f-7eea-4fbe-bba3-ca5623fbbb8a", "ArticleWriter" }
                });
        }
    }
}
