using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class seedAdminUserChangePhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2019, 2, 10, 17, 11, 59, 132, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 10, 17, 11, 59, 148, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "cc0e29fc-00da-4928-bba0-a5b7cb5b76f1", "Client" },
                    { "2ea64121-406d-4f87-bbb4-343766f48e70", "RegularUser" },
                    { "00fa336e-8093-4598-b091-de3883cca662", "Trainer" },
                    { "f2d32601-c378-4f5c-9b91-800aaa5c0892", "ArticleWriter" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt", "PhoneNumber" },
                values: new object[] { new byte[] { 255, 19, 248, 39, 215, 78, 44, 34, 64, 157, 124, 101, 111, 204, 83, 237, 199, 122, 193, 40, 68, 29, 240, 65, 216, 98, 102, 161, 214, 24, 242, 88, 149, 233, 252, 98, 6, 98, 77, 90, 23, 49, 110, 44, 164, 13, 79, 55, 52, 170, 172, 62, 163, 14, 175, 205, 169, 20, 132, 51, 20, 69, 234, 241 }, new byte[] { 168, 34, 141, 233, 106, 64, 18, 247, 32, 199, 185, 222, 53, 47, 230, 229, 192, 217, 60, 46, 215, 160, 224, 17, 217, 64, 244, 219, 161, 132, 56, 69, 228, 92, 58, 59, 118, 33, 126, 5, 167, 204, 92, 88, 163, 44, 94, 45, 19, 121, 254, 119, 239, 20, 253, 248, 128, 76, 223, 40, 170, 252, 141, 26, 200, 188, 19, 68, 154, 183, 80, 147, 154, 189, 92, 32, 236, 65, 98, 116, 154, 193, 190, 134, 38, 52, 141, 60, 130, 84, 249, 162, 129, 120, 54, 125, 3, 71, 160, 36, 110, 151, 232, 2, 245, 213, 211, 236, 35, 33, 155, 125, 70, 40, 218, 3, 221, 124, 237, 236, 168, 216, 80, 62, 37, 174, 134, 80 }, "01014991554" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00fa336e-8093-4598-b091-de3883cca662");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ea64121-406d-4f87-bbb4-343766f48e70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc0e29fc-00da-4928-bba0-a5b7cb5b76f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2d32601-c378-4f5c-9b91-800aaa5c0892");

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
                columns: new[] { "PasswordHash", "PasswordSalt", "PhoneNumber" },
                values: new object[] { new byte[] { 190, 24, 6, 76, 49, 166, 37, 187, 183, 24, 246, 14, 202, 8, 25, 234, 118, 47, 151, 75, 176, 45, 8, 137, 140, 208, 10, 255, 249, 165, 217, 9, 46, 66, 14, 214, 20, 219, 230, 176, 33, 201, 199, 147, 72, 110, 40, 55, 126, 81, 17, 228, 70, 22, 175, 117, 198, 188, 160, 208, 254, 98, 73, 41 }, new byte[] { 89, 137, 46, 105, 67, 81, 24, 210, 157, 93, 251, 43, 109, 153, 158, 11, 7, 23, 223, 227, 30, 43, 15, 144, 43, 149, 157, 149, 104, 242, 5, 126, 176, 201, 158, 142, 51, 46, 38, 38, 90, 195, 78, 36, 14, 87, 248, 88, 203, 111, 117, 51, 163, 36, 3, 129, 95, 244, 12, 47, 182, 96, 3, 179, 240, 219, 66, 40, 1, 213, 91, 240, 3, 71, 4, 192, 200, 76, 124, 46, 71, 107, 172, 164, 238, 30, 192, 142, 172, 213, 140, 103, 151, 47, 111, 154, 209, 9, 251, 164, 116, 133, 53, 231, 95, 237, 122, 83, 204, 214, 72, 5, 8, 43, 178, 24, 246, 194, 56, 88, 112, 99, 190, 177, 54, 180, 88, 196 }, null });
        }
    }
}
