using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class removeProductOwnerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_Owners",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Products_Owners");

            migrationBuilder.DropIndex(
                name: "IX_Products_OwnerId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff8417a-2f20-4070-b8dd-fd975f94ce70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b9d4937-916e-4abd-a877-d25f12a4ad32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7275eed3-5ba9-466b-b7cc-3e4c764a5505");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc566ce0-2f28-4c6d-b95f-7dd54be84d90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed675a88-af4a-4da8-8bb1-649dab9fd2be");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Products");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Products",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Products_Owners",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    ContactInfo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Owners_dbo.AspNetUsers",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1ff8417a-2f20-4070-b8dd-fd975f94ce70", "Client" },
                    { "bc566ce0-2f28-4c6d-b95f-7dd54be84d90", "ProductOwner" },
                    { "ed675a88-af4a-4da8-8bb1-649dab9fd2be", "RegularUser" },
                    { "5b9d4937-916e-4abd-a877-d25f12a4ad32", "Trainer" },
                    { "7275eed3-5ba9-466b-b7cc-3e4c764a5505", "ArticleWriter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OwnerId",
                table: "Products",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_Owners",
                table: "Products",
                column: "OwnerId",
                principalTable: "Products_Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
