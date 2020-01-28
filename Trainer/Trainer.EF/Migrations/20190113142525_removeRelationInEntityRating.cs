using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class removeRelationInEntityRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRatings_ItemsForReviews_ItemsForReviewId",
                table: "EntityRatings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57ff8bc7-860e-4436-b50d-1b1052bab4e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "694b82c4-21d0-4406-a010-984562d47631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6cb885e-a9f1-4b78-97f1-3fec72aa2982");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff9eecba-da67-4049-92e4-e9253f74bcaf");

            migrationBuilder.AlterColumn<int>(
                name: "ItemsForReviewId",
                table: "EntityRatings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "EntityRatings",
                nullable: false,
                defaultValue: 0);

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
                name: "FK_EntityRatings_ItemsForReviews_ItemsForReviewId",
                table: "EntityRatings",
                column: "ItemsForReviewId",
                principalTable: "ItemsForReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRatings_ItemsForReviews_ItemsForReviewId",
                table: "EntityRatings");

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
                name: "EntityId",
                table: "EntityRatings");

            migrationBuilder.AlterColumn<int>(
                name: "ItemsForReviewId",
                table: "EntityRatings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 12, 11, 34, 24, 9, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 1, 12, 11, 34, 24, 41, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "57ff8bc7-860e-4436-b50d-1b1052bab4e0", "Client" },
                    { "ff9eecba-da67-4049-92e4-e9253f74bcaf", "RegularUser" },
                    { "694b82c4-21d0-4406-a010-984562d47631", "Trainer" },
                    { "c6cb885e-a9f1-4b78-97f1-3fec72aa2982", "ArticleWriter" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRatings_ItemsForReviews_ItemsForReviewId",
                table: "EntityRatings",
                column: "ItemsForReviewId",
                principalTable: "ItemsForReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
