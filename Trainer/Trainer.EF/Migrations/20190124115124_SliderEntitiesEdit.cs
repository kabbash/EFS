using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class SliderEntitiesEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesImages_Articles_ArticleId",
                table: "ArticlesImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "363965f3-002e-4b7e-ba29-35e6ff05e365");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46abd3c0-815b-4bdb-af31-f80671832df2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "655bd8e2-4fc4-42cd-9aa3-5d6b80034612");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7431fd78-5e03-47f3-95ae-2ddb18f065a7");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products_Images");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Clients_Images");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Programs_Images",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "Programs_Images",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Programs_Images_ProgramId",
                table: "Programs_Images",
                newName: "IX_Programs_Images_ParentId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products_Images",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Images_ProductId",
                table: "Products_Images",
                newName: "IX_Products_Images_ParentId");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "ArticlesImages",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "ArticlesImages",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticlesImages_ArticleId",
                table: "ArticlesImages",
                newName: "IX_ArticlesImages_ParentId");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 24, 11, 51, 21, 917, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 24, 11, 51, 21, 922, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "c478e23e-b1f5-4f43-90da-e0a3036a3efe", "Client" },
                    { "eda5c1de-fa0c-4bc5-80e2-bc0b3ef79e5f", "RegularUser" },
                    { "dd07ee20-c827-4513-bab1-041f54469eab", "Trainer" },
                    { "e3a41851-4edd-4175-a70b-e281a998510d", "ArticleWriter" }
                });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "hamda" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesImages_Articles_ParentId",
                table: "ArticlesImages",
                column: "ParentId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlesImages_Articles_ParentId",
                table: "ArticlesImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c478e23e-b1f5-4f43-90da-e0a3036a3efe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd07ee20-c827-4513-bab1-041f54469eab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3a41851-4edd-4175-a70b-e281a998510d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eda5c1de-fa0c-4bc5-80e2-bc0b3ef79e5f");

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Programs_Images",
                newName: "ProgramId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Programs_Images",
                newName: "Text");

            migrationBuilder.RenameIndex(
                name: "IX_Programs_Images_ParentId",
                table: "Programs_Images",
                newName: "IX_Programs_Images_ProgramId");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Products_Images",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Images_ParentId",
                table: "Products_Images",
                newName: "IX_Products_Images_ProductId");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "ArticlesImages",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ArticlesImages",
                newName: "Text");

            migrationBuilder.RenameIndex(
                name: "IX_ArticlesImages_ParentId",
                table: "ArticlesImages",
                newName: "IX_ArticlesImages_ArticleId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products_Images",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Clients_Images",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 13, 14, 25, 9, 630, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 13, 14, 25, 9, 663, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "46abd3c0-815b-4bdb-af31-f80671832df2", "Client" },
                    { "363965f3-002e-4b7e-ba29-35e6ff05e365", "RegularUser" },
                    { "7431fd78-5e03-47f3-95ae-2ddb18f065a7", "Trainer" },
                    { "655bd8e2-4fc4-42cd-9aa3-5d6b80034612", "ArticleWriter" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlesImages_Articles_ArticleId",
                table: "ArticlesImages",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
