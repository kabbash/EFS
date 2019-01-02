using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class OnDeleteProductCategoryDeleteProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Products_Products_Subcategories",
            //    table: "Products");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "bac261b9-6c8d-4241-b5ce-840e0c6eadea", "Client" },
                    { "ede24b4a-82ab-42cf-8453-cc5d31a7eebe", "RegularUser" },
                    { "a55a10d6-f868-4f9b-8bd8-d5ff25379f6a", "Trainer" },
                    { "d4d36b15-a911-42d0-8c2b-f49f0ca9d032", "ArticleWriter" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_Subcategories",
                table: "Products",
                column: "CategoryId",
                principalTable: "Products_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_Subcategories",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a55a10d6-f868-4f9b-8bd8-d5ff25379f6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bac261b9-6c8d-4241-b5ce-840e0c6eadea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4d36b15-a911-42d0-8c2b-f49f0ca9d032");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ede24b4a-82ab-42cf-8453-cc5d31a7eebe");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_Subcategories",
                table: "Products",
                column: "CategoryId",
                principalTable: "Products_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
