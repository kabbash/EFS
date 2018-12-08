using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddItemsForReview : Migration
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

            migrationBuilder.CreateTable(
                name: "ItemsForReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsForReviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "ba272a71-af11-45c9-aae6-22446d1dedf8", "Client" },
                    { "7bc17a2d-58db-4c66-90c5-1c45ffc6f5e1", "RegularUser" },
                    { "4069377a-71c7-40f3-9517-a1f66a9b0616", "Trainer" },
                    { "3d548255-06cc-4026-bb6f-47e0123aff28", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsForReviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d548255-06cc-4026-bb6f-47e0123aff28");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4069377a-71c7-40f3-9517-a1f66a9b0616");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bc17a2d-58db-4c66-90c5-1c45ffc6f5e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba272a71-af11-45c9-aae6-22446d1dedf8");

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
