using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class removeAuthorIdFromArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0240e6ae-5098-45ee-baf4-4eb76e805ec9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "272e05d3-7035-4435-90eb-d08624f3c670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9316308f-dd8a-4cfc-9390-2a3724ecb603");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa0fd9d9-0b39-4a32-85d2-0f629897f770");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f09fdda7-1200-4d01-aac8-e4631bb4420c");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Articles");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Products",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "7bc144ee-0c0f-4be4-a9fb-88504fe83f71", "Client" },
                    { "af7edf6b-13de-4958-97c0-8bbce5594c87", "ProductOwner" },
                    { "ac3bd65b-dcc0-4a39-bcac-cd4324e3437d", "RegularUser" },
                    { "9f789b13-865a-4715-9fd6-7f270a57fbf5", "Trainer" },
                    { "423d3428-373e-4c7a-be3c-5dc932b63cef", "ArticleWriter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatedBy",
                table: "Articles",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_CreatedBy",
                table: "Articles",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_CreatedBy",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CreatedBy",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "423d3428-373e-4c7a-be3c-5dc932b63cef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bc144ee-0c0f-4be4-a9fb-88504fe83f71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f789b13-865a-4715-9fd6-7f270a57fbf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac3bd65b-dcc0-4a39-bcac-cd4324e3437d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7edf6b-13de-4958-97c0-8bbce5594c87");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Articles",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "9316308f-dd8a-4cfc-9390-2a3724ecb603", "Client" },
                    { "272e05d3-7035-4435-90eb-d08624f3c670", "ProductOwner" },
                    { "f09fdda7-1200-4d01-aac8-e4631bb4420c", "RegularUser" },
                    { "aa0fd9d9-0b39-4a32-85d2-0f629897f770", "Trainer" },
                    { "0240e6ae-5098-45ee-baf4-4eb76e805ec9", "ArticleWriter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers",
                table: "Articles",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
