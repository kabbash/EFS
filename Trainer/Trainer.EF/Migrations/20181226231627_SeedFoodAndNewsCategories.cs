using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class SeedFoodAndNewsCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41147d1b-1600-4e5e-b33b-bc5b7e230f31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eac1aa7e-8e7c-47de-8427-c9ba6afccadb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4f490e2-ab49-4a07-b042-75c5409bf24a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc164fb1-5f0b-43e4-9d66-14f506e1cc96");

            migrationBuilder.InsertData(
                table: "Articles_Categories",
                columns: new[] { "Id", "Name", "PredefinedKey", "CreatedAt", "CreatedBy", "ProfilePicture" },
                values: new object[,]
                {
                    {1, "وصفات الطعام" , 2, new DateTime(2018, 12, 26, 23, 16, 25, 354, DateTimeKind.Utc), "admin", "Files/Articles%20Categories/food.png"},
                    {2, "الأخبار" , 1, new DateTime(2018, 12, 26, 23, 16, 25, 354, DateTimeKind.Utc), "admin", "Files/Articles%20Categories/news.png"}

                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "86b4fd7d-6d0e-4110-a4d2-ffc8be7287e3", "Client" },
                    { "4ac33132-1e0e-4f53-84d7-d83929ff12ba", "RegularUser" },
                    { "310a2097-0331-4c0d-9722-d2cc648d3c4c", "Trainer" },
                    { "56eff314-1322-4942-991f-dbebbb386c40", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "310a2097-0331-4c0d-9722-d2cc648d3c4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ac33132-1e0e-4f53-84d7-d83929ff12ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56eff314-1322-4942-991f-dbebbb386c40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86b4fd7d-6d0e-4110-a4d2-ffc8be7287e3");

            migrationBuilder.DeleteData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "fc164fb1-5f0b-43e4-9d66-14f506e1cc96", "Client" },
                    { "f4f490e2-ab49-4a07-b042-75c5409bf24a", "RegularUser" },
                    { "eac1aa7e-8e7c-47de-8427-c9ba6afccadb", "Trainer" },
                    { "41147d1b-1600-4e5e-b33b-bc5b7e230f31", "ArticleWriter" }
                });
        }
    }
}
