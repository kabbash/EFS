using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class ChangeProductImagesPropNameInProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2019, 2, 3, 16, 33, 13, 208, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 3, 16, 33, 13, 210, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "40bee09c-4fb9-4f3d-92b4-f64fc375fa4a", "Client" },
                    { "7ef5afa8-fa6a-490c-a0e6-a4a027b7a9ee", "RegularUser" },
                    { "8767beb7-e38d-42fa-8dae-7a7e34255c57", "Trainer" },
                    { "7ef6ee26-7e72-4e78-831c-4519458ed078", "ArticleWriter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40bee09c-4fb9-4f3d-92b4-f64fc375fa4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ef5afa8-fa6a-490c-a0e6-a4a027b7a9ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ef6ee26-7e72-4e78-831c-4519458ed078");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8767beb7-e38d-42fa-8dae-7a7e34255c57");

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
        }
    }
}
