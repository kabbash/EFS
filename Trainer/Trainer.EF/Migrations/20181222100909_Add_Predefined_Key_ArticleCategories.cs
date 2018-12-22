using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class Add_Predefined_Key_ArticleCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PredefinedCategoryKey",
                table: "Articles_Categories",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0d706a31-8998-41f2-9e99-7a8d9afdd8c3", "Client" },
                    { "c9732565-1c73-4e11-a922-fe861ddd7b53", "RegularUser" },
                    { "bfade08c-cbbd-4324-963a-fbc7b9190db1", "Trainer" },
                    { "86b1413a-a7bf-49fe-a52a-9e5f8f2b54bb", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d706a31-8998-41f2-9e99-7a8d9afdd8c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86b1413a-a7bf-49fe-a52a-9e5f8f2b54bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfade08c-cbbd-4324-963a-fbc7b9190db1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9732565-1c73-4e11-a922-fe861ddd7b53");

            migrationBuilder.DropColumn(
                name: "PredefinedCategoryKey",
                table: "Articles_Categories");

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
    }
}
