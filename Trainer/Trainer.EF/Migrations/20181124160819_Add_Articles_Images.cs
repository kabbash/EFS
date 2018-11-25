using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class Add_Articles_Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ArticlesImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlesImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticlesImages_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "f006c66e-85ac-4945-aa7d-937d68765031", "Client" },
                    { "6ee6ab0c-7dd6-46fe-8095-d507e336f448", "RegularUser" },
                    { "119ff683-82a6-4b3c-b43a-ad176e3327a4", "Trainer" },
                    { "b7e42906-c642-4944-ac09-068871e36340", "ArticleWriter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticlesImages_ArticleId",
                table: "ArticlesImages",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticlesImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "119ff683-82a6-4b3c-b43a-ad176e3327a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee6ab0c-7dd6-46fe-8095-d507e336f448");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7e42906-c642-4944-ac09-068871e36340");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f006c66e-85ac-4945-aa7d-937d68765031");

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
        }
    }
}
