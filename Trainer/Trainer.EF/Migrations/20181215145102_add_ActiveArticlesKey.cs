using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class add_ActiveArticlesKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f05de72-f93c-4290-b070-a510a6dd9e59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc4d4a9c-3e3b-4da2-ae9a-4a94cac04320");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1e1fa1b-af56-4461-8c43-9f6d7916be40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e542b29c-89af-4d12-95c4-0614aa698d12");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Articles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "3c36fa5c-a2ae-4cdb-acaf-ea8ae95d3724", "Client" },
                    { "4d81fd82-afb7-4b9e-b626-16426452c972", "RegularUser" },
                    { "318eb328-d58f-4d0d-96f5-18f92c34baba", "Trainer" },
                    { "64d55e0a-9afd-402c-b252-6add865ed539", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "318eb328-d58f-4d0d-96f5-18f92c34baba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c36fa5c-a2ae-4cdb-acaf-ea8ae95d3724");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d81fd82-afb7-4b9e-b626-16426452c972");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64d55e0a-9afd-402c-b252-6add865ed539");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0f05de72-f93c-4290-b070-a510a6dd9e59", "Client" },
                    { "e542b29c-89af-4d12-95c4-0614aa698d12", "RegularUser" },
                    { "cc4d4a9c-3e3b-4da2-ae9a-4a94cac04320", "Trainer" },
                    { "d1e1fa1b-af56-4461-8c43-9f6d7916be40", "ArticleWriter" }
                });
        }
    }
}
