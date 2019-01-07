using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class EntityRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5560dcd1-6a17-4d09-8128-a3e67fd55a2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e9c9ace-75e9-4913-b7d6-db5240aab551");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a99c2b47-4208-402b-994b-fb11d7cf1010");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db4f70df-8e98-4b9a-9460-a0c2444b2097");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "EntityRatings",
                newName: "ItemsForReviewId");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EntityRatings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 6, 15, 16, 7, 882, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 6, 15, 16, 7, 884, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "819991a4-5ab7-47b6-b7ae-12278cec1422", "Client" },
                    { "f3ad873c-136b-4dc1-bf00-7b230e74cd52", "RegularUser" },
                    { "08dc5a08-68e0-46ba-9122-46e633294314", "Trainer" },
                    { "8dd8ea17-a222-4d5f-87c1-9e049fbc59a8", "ArticleWriter" }
                });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "product" });

            migrationBuilder.CreateIndex(
                name: "IX_EntityRatings_CreatedBy",
                table: "EntityRatings",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRatings_ItemsForReviewId",
                table: "EntityRatings",
                column: "ItemsForReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRatings_AspNetUsers_CreatedBy",
                table: "EntityRatings",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRatings_ItemsForReviews_ItemsForReviewId",
                table: "EntityRatings",
                column: "ItemsForReviewId",
                principalTable: "ItemsForReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRatings_AspNetUsers_CreatedBy",
                table: "EntityRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRatings_ItemsForReviews_ItemsForReviewId",
                table: "EntityRatings");

            migrationBuilder.DropIndex(
                name: "IX_EntityRatings_CreatedBy",
                table: "EntityRatings");

            migrationBuilder.DropIndex(
                name: "IX_EntityRatings_ItemsForReviewId",
                table: "EntityRatings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08dc5a08-68e0-46ba-9122-46e633294314");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "819991a4-5ab7-47b6-b7ae-12278cec1422");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dd8ea17-a222-4d5f-87c1-9e049fbc59a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3ad873c-136b-4dc1-bf00-7b230e74cd52");

            migrationBuilder.DeleteData(
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "ItemsForReviewId",
                table: "EntityRatings",
                newName: "EntityId");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EntityRatings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 23, 23, 6, 972, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 1, 23, 23, 6, 975, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "5560dcd1-6a17-4d09-8128-a3e67fd55a2a", "Client" },
                    { "5e9c9ace-75e9-4913-b7d6-db5240aab551", "RegularUser" },
                    { "a99c2b47-4208-402b-994b-fb11d7cf1010", "Trainer" },
                    { "db4f70df-8e98-4b9a-9460-a0c2444b2097", "ArticleWriter" }
                });
        }
    }
}
