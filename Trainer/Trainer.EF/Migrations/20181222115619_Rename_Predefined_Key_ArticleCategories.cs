using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class Rename_Predefined_Key_ArticleCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "PredefinedCategoryKey",
                table: "Articles_Categories",
                newName: "PredefinedKey");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "3f8fbe80-843c-4973-b2cb-edd5cc7adef3", "Client" },
                    { "e357d87e-2243-4ad9-b292-d62b70127f6e", "RegularUser" },
                    { "ac2270bd-216b-4ebe-ae35-985dcdb7d3c8", "Trainer" },
                    { "f2400f39-2ad1-4768-ad71-6e8acc7001de", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8fbe80-843c-4973-b2cb-edd5cc7adef3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac2270bd-216b-4ebe-ae35-985dcdb7d3c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e357d87e-2243-4ad9-b292-d62b70127f6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2400f39-2ad1-4768-ad71-6e8acc7001de");

            migrationBuilder.RenameColumn(
                name: "PredefinedKey",
                table: "Articles_Categories",
                newName: "PredefinedCategoryKey");

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
    }
}
