using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class SeedChampionShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 24, 17, 31, 50, 946, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 24, 17, 31, 50, 948, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "Articles_Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "PredefinedKey", "ProfilePicture", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 3, new DateTime(2019, 2, 24, 17, 31, 50, 948, DateTimeKind.Utc), "admin", "البطولات", 3, "Files/Articles%20Categories/championships.png", null, null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 77, 105, 21, 189, 239, 182, 89, 202, 23, 8, 201, 125, 184, 232, 87, 251, 73, 153, 52, 111, 163, 174, 166, 35, 38, 128, 117, 63, 84, 61, 53, 202, 33, 156, 1, 112, 121, 185, 14, 170, 137, 214, 78, 109, 29, 155, 36, 108, 41, 129, 220, 55, 154, 145, 254, 208, 19, 113, 176, 201, 235, 209, 134, 35 }, new byte[] { 255, 219, 23, 55, 93, 100, 173, 120, 132, 114, 215, 205, 247, 131, 89, 183, 211, 95, 112, 94, 34, 202, 104, 255, 121, 227, 216, 63, 14, 74, 114, 182, 175, 182, 56, 198, 17, 124, 146, 134, 176, 243, 190, 201, 29, 39, 188, 4, 119, 188, 45, 116, 71, 223, 215, 236, 165, 250, 220, 214, 52, 107, 131, 22, 74, 78, 57, 216, 38, 214, 176, 61, 37, 213, 31, 243, 250, 32, 11, 69, 130, 183, 193, 64, 82, 64, 200, 2, 76, 159, 231, 148, 121, 187, 204, 75, 77, 57, 190, 140, 112, 164, 244, 190, 2, 62, 51, 201, 178, 191, 198, 240, 147, 160, 15, 204, 209, 228, 195, 47, 211, 143, 45, 227, 230, 229, 250, 238 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 16, 21, 20, 29, 340, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 16, 21, 20, 29, 344, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 184, 98, 51, 63, 83, 246, 55, 82, 45, 22, 116, 245, 24, 16, 192, 242, 225, 14, 224, 41, 242, 17, 182, 47, 63, 255, 224, 122, 74, 139, 36, 223, 35, 23, 99, 55, 188, 136, 39, 10, 254, 173, 153, 211, 56, 84, 94, 129, 1, 28, 186, 149, 146, 143, 107, 26, 221, 246, 96, 28, 68, 28, 108 }, new byte[] { 63, 135, 205, 171, 193, 202, 123, 164, 216, 5, 46, 255, 36, 200, 131, 155, 113, 49, 166, 18, 108, 107, 167, 66, 160, 97, 33, 125, 168, 54, 17, 78, 233, 198, 135, 24, 179, 215, 88, 244, 125, 152, 197, 156, 93, 187, 104, 219, 133, 82, 132, 254, 219, 240, 175, 207, 71, 250, 143, 244, 117, 12, 99, 69, 21, 126, 193, 144, 172, 56, 120, 208, 119, 120, 151, 21, 210, 167, 123, 75, 170, 125, 1, 35, 89, 69, 245, 42, 12, 201, 55, 231, 143, 32, 227, 1, 65, 206, 60, 74, 227, 164, 68, 113, 126, 70, 156, 120, 71, 56, 136, 84, 133, 101, 48, 74, 190, 65, 83, 123, 244, 126, 223, 112, 79, 60, 18, 127 } });
        }
    }
}
