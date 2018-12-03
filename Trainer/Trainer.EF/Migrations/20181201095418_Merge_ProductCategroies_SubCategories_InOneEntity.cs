using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class Merge_ProductCategroies_SubCategories_InOneEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_Subcategories",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Products_Subcategories");

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

            migrationBuilder.RenameColumn(
                name: "SubcategoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Products_Categories",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "329a63df-98b4-4919-ad33-44ad05789e75", "Client" },
                    { "b3eb6e0b-1fa2-4cbb-a1b8-5d1525847b09", "RegularUser" },
                    { "18effbce-f41b-4dd7-a9e5-5c21d8f743e5", "Trainer" },
                    { "a1990a1f-7eea-4fbe-bba3-ca5623fbbb8a", "ArticleWriter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Categories_ParentId",
                table: "Products_Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_Categories",
                table: "Products",
                column: "CategoryId",
                principalTable: "Products_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_Products_Categories_ParentId",
                table: "Products_Categories",
                column: "ParentId",
                principalTable: "Products_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_Subcategories",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_Products_Categories_ParentId",
                table: "Products_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_Categories_ParentId",
                table: "Products_Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18effbce-f41b-4dd7-a9e5-5c21d8f743e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "329a63df-98b4-4919-ad33-44ad05789e75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1990a1f-7eea-4fbe-bba3-ca5623fbbb8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3eb6e0b-1fa2-4cbb-a1b8-5d1525847b09");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Products_Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "SubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_SubcategoryId");

            migrationBuilder.CreateTable(
                name: "Products_Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Subcategories_Products_Categories",
                        column: x => x.CategoryId,
                        principalTable: "Products_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Products_Subcategories_CategoryId",
                table: "Products_Subcategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_Subcategories",
                table: "Products",
                column: "SubcategoryId",
                principalTable: "Products_Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
