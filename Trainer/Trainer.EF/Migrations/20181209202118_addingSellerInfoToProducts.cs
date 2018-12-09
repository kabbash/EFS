using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class addingSellerInfoToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2677c844-24f9-43e5-9694-640c163624fe", "Client" },
                    { "da2a8a88-fee2-4d52-b0f0-019863d33f76", "RegularUser" },
                    { "bd325567-d68d-4ba5-8423-90230ddba9b7", "Trainer" },
                    { "9d09f971-9a1e-4d2d-bb65-6deaaf205f30", "ArticleWriter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedBy",
                table: "Products",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedBy",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2677c844-24f9-43e5-9694-640c163624fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d09f971-9a1e-4d2d-bb65-6deaaf205f30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd325567-d68d-4ba5-8423-90230ddba9b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da2a8a88-fee2-4d52-b0f0-019863d33f76");

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
    }
}
