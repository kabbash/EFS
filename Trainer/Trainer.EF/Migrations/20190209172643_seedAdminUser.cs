using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class seedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2019, 2, 9, 17, 26, 29, 194, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 17, 26, 29, 207, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "d1f37fd7-e23a-482b-86ae-fc67baa1a9a8", "Client" },
                    { "9e1984ac-b268-4a79-980e-18a48f00e04e", "RegularUser" },
                    { "ba5154c5-b53c-4345-96e7-bce3e9ce68a2", "Trainer" },
                    { "70d545ec-0d26-4bd3-b4fb-cd135f6f5c54", "ArticleWriter" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 209, 10, 210, 173, 112, 106, 151, 81, 118, 45, 203, 190, 104, 58, 166, 220, 182, 249, 184, 63, 122, 93, 221, 97, 230, 183, 14, 104, 11, 197, 169, 212, 119, 116, 8, 187, 74, 65, 159, 7, 162, 233, 155, 208, 57, 246, 62, 110, 50, 169, 229, 66, 86, 238, 185, 54, 131, 227, 17, 163, 152, 191, 152, 118 }, new byte[] { 165, 53, 195, 160, 38, 159, 69, 208, 13, 13, 114, 67, 127, 89, 88, 161, 170, 29, 82, 71, 164, 17, 54, 61, 43, 16, 86, 2, 74, 35, 185, 113, 34, 74, 147, 188, 158, 235, 82, 253, 140, 167, 160, 229, 123, 191, 38, 164, 67, 100, 231, 91, 229, 237, 28, 68, 158, 66, 190, 253, 108, 16, 239, 101, 11, 246, 252, 238, 47, 3, 227, 152, 107, 13, 3, 42, 112, 230, 230, 212, 189, 95, 61, 48, 155, 220, 75, 7, 43, 5, 43, 139, 88, 209, 129, 10, 190, 88, 45, 251, 114, 153, 105, 23, 163, 23, 211, 48, 197, 135, 110, 171, 93, 52, 96, 51, 246, 54, 196, 125, 96, 237, 118, 110, 10, 1, 181, 231 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70d545ec-0d26-4bd3-b4fb-cd135f6f5c54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e1984ac-b268-4a79-980e-18a48f00e04e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba5154c5-b53c-4345-96e7-bce3e9ce68a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1f37fd7-e23a-482b-86ae-fc67baa1a9a8");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { null, null });
        }
    }
}
