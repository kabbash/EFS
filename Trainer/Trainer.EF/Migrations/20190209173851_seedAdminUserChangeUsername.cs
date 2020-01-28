using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class seedAdminUserChangeUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2019, 2, 9, 17, 38, 47, 823, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 9, 17, 38, 47, 825, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "785435d0-80ed-4791-bfec-356c29bed814", "Client" },
                    { "409a759b-edf2-404b-b060-2b50d06bcc14", "RegularUser" },
                    { "9823bdae-57e2-493e-a08c-fa5962d21d48", "Trainer" },
                    { "3e6a4e93-9ffc-4223-8fe3-8e1aa2e18fd5", "ArticleWriter" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new byte[] { 190, 24, 6, 76, 49, 166, 37, 187, 183, 24, 246, 14, 202, 8, 25, 234, 118, 47, 151, 75, 176, 45, 8, 137, 140, 208, 10, 255, 249, 165, 217, 9, 46, 66, 14, 214, 20, 219, 230, 176, 33, 201, 199, 147, 72, 110, 40, 55, 126, 81, 17, 228, 70, 22, 175, 117, 198, 188, 160, 208, 254, 98, 73, 41 }, new byte[] { 89, 137, 46, 105, 67, 81, 24, 210, 157, 93, 251, 43, 109, 153, 158, 11, 7, 23, 223, 227, 30, 43, 15, 144, 43, 149, 157, 149, 104, 242, 5, 126, 176, 201, 158, 142, 51, 46, 38, 38, 90, 195, 78, 36, 14, 87, 248, 88, 203, 111, 117, 51, 163, 36, 3, 129, 95, 244, 12, 47, 182, 96, 3, 179, 240, 219, 66, 40, 1, 213, 91, 240, 3, 71, 4, 192, 200, 76, 124, 46, 71, 107, 172, 164, 238, 30, 192, 142, 172, 213, 140, 103, 151, 47, 111, 154, 209, 9, 251, 164, 116, 133, 53, 231, 95, 237, 122, 83, 204, 214, 72, 5, 8, 43, 178, 24, 246, 194, 56, 88, 112, 99, 190, 177, 54, 180, 88, 196 }, "ahmedkabbash@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e6a4e93-9ffc-4223-8fe3-8e1aa2e18fd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "409a759b-edf2-404b-b060-2b50d06bcc14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "785435d0-80ed-4791-bfec-356c29bed814");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9823bdae-57e2-493e-a08c-fa5962d21d48");

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
                columns: new[] { "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new byte[] { 209, 10, 210, 173, 112, 106, 151, 81, 118, 45, 203, 190, 104, 58, 166, 220, 182, 249, 184, 63, 122, 93, 221, 97, 230, 183, 14, 104, 11, 197, 169, 212, 119, 116, 8, 187, 74, 65, 159, 7, 162, 233, 155, 208, 57, 246, 62, 110, 50, 169, 229, 66, 86, 238, 185, 54, 131, 227, 17, 163, 152, 191, 152, 118 }, new byte[] { 165, 53, 195, 160, 38, 159, 69, 208, 13, 13, 114, 67, 127, 89, 88, 161, 170, 29, 82, 71, 164, 17, 54, 61, 43, 16, 86, 2, 74, 35, 185, 113, 34, 74, 147, 188, 158, 235, 82, 253, 140, 167, 160, 229, 123, 191, 38, 164, 67, 100, 231, 91, 229, 237, 28, 68, 158, 66, 190, 253, 108, 16, 239, 101, 11, 246, 252, 238, 47, 3, 227, 152, 107, 13, 3, 42, 112, 230, 230, 212, 189, 95, 61, 48, 155, 220, 75, 7, 43, 5, 43, 139, 88, 209, 129, 10, 190, 88, 45, 251, 114, 153, 105, 23, 163, 23, 211, 48, 197, 135, 110, 171, 93, 52, 96, 51, 246, 54, 196, 125, 96, 237, 118, 110, 10, 1, 181, 231 }, "Admin" });
        }
    }
}
