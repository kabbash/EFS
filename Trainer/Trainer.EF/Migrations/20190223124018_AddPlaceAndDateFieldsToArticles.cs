using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddPlaceAndDateFieldsToArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Articles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 23, 12, 40, 16, 348, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 23, 12, 40, 16, 352, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 218, 207, 69, 166, 235, 103, 82, 231, 5, 111, 112, 232, 203, 145, 25, 101, 212, 172, 189, 80, 43, 15, 217, 175, 219, 92, 124, 215, 188, 136, 30, 125, 126, 207, 104, 39, 142, 188, 226, 157, 92, 194, 164, 73, 83, 224, 113, 244, 112, 195, 144, 82, 149, 180, 116, 245, 242, 183, 247, 62, 32, 113, 150, 186 }, new byte[] { 172, 161, 120, 109, 175, 39, 49, 189, 229, 25, 155, 132, 44, 199, 46, 159, 254, 171, 123, 40, 135, 81, 15, 127, 153, 134, 150, 60, 127, 46, 81, 187, 213, 212, 12, 48, 180, 194, 242, 114, 6, 131, 161, 196, 165, 5, 179, 81, 135, 114, 11, 128, 78, 135, 139, 76, 163, 112, 151, 120, 240, 247, 168, 41, 53, 192, 53, 75, 105, 193, 192, 202, 122, 56, 193, 2, 183, 122, 106, 58, 69, 26, 162, 26, 143, 33, 92, 13, 34, 24, 17, 163, 166, 15, 94, 228, 217, 49, 20, 159, 189, 187, 225, 29, 221, 252, 78, 137, 60, 206, 145, 249, 135, 127, 179, 21, 62, 8, 49, 239, 213, 204, 83, 18, 43, 113, 208, 73 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Articles");

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
