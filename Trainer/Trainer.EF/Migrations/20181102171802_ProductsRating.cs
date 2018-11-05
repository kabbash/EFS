using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class ProductsRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b8f61f4-7d5a-4b74-89ee-d0d11dc126e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36714f5a-e957-4876-83d9-873a590531dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7c62486-4265-483d-9231-f60fdebf2d0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfedd55d-46c3-4e06-b29d-00bdb18bab47");

            migrationBuilder.CreateTable(
                name: "ProductsRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsRatings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "9f4d24f9-e67e-461d-a9f2-61c7603ce619", "Client" },
                    { "fda1869e-f714-47a8-a456-77def1d1fa38", "ProductOwner" },
                    { "cab84034-ba13-4d47-b7b0-d6973e30ce84", "RegularUser" },
                    { "5cfc83f8-9682-4e26-8682-a3bd8055a0c1", "Trainer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsRatings_ProductId",
                table: "ProductsRatings",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsRatings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cfc83f8-9682-4e26-8682-a3bd8055a0c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f4d24f9-e67e-461d-a9f2-61c7603ce619");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cab84034-ba13-4d47-b7b0-d6973e30ce84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fda1869e-f714-47a8-a456-77def1d1fa38");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "a7c62486-4265-483d-9231-f60fdebf2d0a", "Client" },
                    { "0b8f61f4-7d5a-4b74-89ee-d0d11dc126e2", "ProductOwner" },
                    { "bfedd55d-46c3-4e06-b29d-00bdb18bab47", "RegularUser" },
                    { "36714f5a-e957-4876-83d9-873a590531dd", "Trainer" }
                });
        }
    }
}
