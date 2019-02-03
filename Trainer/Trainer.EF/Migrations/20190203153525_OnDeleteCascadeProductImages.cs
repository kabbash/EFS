using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class OnDeleteCascadeProductImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_Products",
                table: "Products_Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04a38259-cdfe-4f81-9b46-253cbd27ff3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bb2fc24-ec5e-43aa-8fcc-8ea8800ae41d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3458c1f-c840-4050-ad1e-b5b48cecbf78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5774e77-a2a8-465a-a842-625d37015919");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 3, 15, 35, 24, 142, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 3, 15, 35, 24, 144, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "bb803b38-1898-4ee3-a66e-a8381dae1a8c", "Client" },
                    { "c159ac8f-e7a0-4b7b-b423-646467888bac", "RegularUser" },
                    { "c805b501-ca6e-4e70-9473-b22bc54133c6", "Trainer" },
                    { "f35b2a61-b4a8-4736-a8d6-483c4c0a824b", "ArticleWriter" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_Products",
                table: "Products_Images",
                column: "ParentId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_Products",
                table: "Products_Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb803b38-1898-4ee3-a66e-a8381dae1a8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c159ac8f-e7a0-4b7b-b423-646467888bac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c805b501-ca6e-4e70-9473-b22bc54133c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f35b2a61-b4a8-4736-a8d6-483c4c0a824b");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 2, 12, 16, 9, 914, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 2, 12, 16, 9, 921, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "e5774e77-a2a8-465a-a842-625d37015919", "Client" },
                    { "0bb2fc24-ec5e-43aa-8fcc-8ea8800ae41d", "RegularUser" },
                    { "04a38259-cdfe-4f81-9b46-253cbd27ff3b", "Trainer" },
                    { "e3458c1f-c840-4050-ad1e-b5b48cecbf78", "ArticleWriter" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_Products",
                table: "Products_Images",
                column: "ParentId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
