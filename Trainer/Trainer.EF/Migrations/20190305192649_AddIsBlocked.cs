using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddIsBlocked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 5, 19, 26, 47, 440, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 5, 19, 26, 47, 443, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 5, 19, 26, 47, 443, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 103, 13, 102, 122, 0, 123, 210, 79, 71, 52, 199, 182, 144, 142, 151, 123, 117, 16, 63, 134, 33, 156, 58, 43, 23, 90, 187, 33, 91, 100, 136, 178, 219, 251, 254, 254, 20, 24, 225, 64, 121, 110, 142, 147, 75, 33, 211, 20, 139, 175, 206, 151, 112, 192, 148, 101, 64, 53, 182, 253, 174, 74, 35, 146 }, new byte[] { 186, 251, 13, 151, 209, 120, 16, 95, 228, 154, 143, 11, 234, 20, 66, 128, 121, 155, 82, 149, 176, 147, 192, 79, 253, 221, 15, 254, 53, 17, 188, 139, 194, 223, 136, 89, 189, 95, 226, 173, 194, 164, 121, 130, 139, 240, 223, 248, 39, 84, 139, 77, 34, 163, 186, 131, 147, 242, 168, 119, 200, 62, 23, 2, 242, 30, 91, 30, 139, 173, 153, 79, 197, 102, 43, 53, 42, 10, 215, 83, 65, 60, 230, 194, 133, 104, 239, 62, 96, 246, 200, 165, 74, 227, 58, 236, 75, 70, 29, 150, 4, 208, 117, 46, 196, 67, 165, 127, 93, 245, 240, 175, 239, 163, 58, 4, 185, 68, 153, 198, 95, 186, 157, 253, 218, 189, 203, 70 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "AspNetUsers");

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

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 24, 17, 31, 50, 948, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 218, 207, 69, 166, 235, 103, 82, 231, 5, 111, 112, 232, 203, 145, 25, 101, 212, 172, 189, 80, 43, 15, 217, 175, 219, 92, 124, 215, 188, 136, 30, 125, 126, 207, 104, 39, 142, 188, 226, 157, 92, 194, 164, 73, 83, 224, 113, 244, 112, 195, 144, 82, 149, 180, 116, 245, 242, 183, 247, 62, 32, 113, 150, 186 }, new byte[] { 172, 161, 120, 109, 175, 39, 49, 189, 229, 25, 155, 132, 44, 199, 46, 159, 254, 171, 123, 40, 135, 81, 15, 127, 153, 134, 150, 60, 127, 46, 81, 187, 213, 212, 12, 48, 180, 194, 242, 114, 6, 131, 161, 196, 165, 5, 179, 81, 135, 114, 11, 128, 78, 135, 139, 76, 163, 112, 151, 120, 240, 247, 168, 41, 53, 192, 53, 75, 105, 193, 192, 202, 122, 56, 193, 2, 183, 122, 106, 58, 69, 26, 162, 26, 143, 33, 92, 13, 34, 24, 17, 163, 166, 15, 94, 228, 217, 49, 20, 159, 189, 187, 225, 29, 221, 252, 78, 137, 60, 206, 145, 249, 135, 127, 179, 21, 62, 8, 49, 239, 213, 204, 83, 18, 43, 113, 208, 73 } });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "product" },
                    { 4, "hamda" },
                    { 9, "m7maaa ma7rooos" }
                });
        }
    }
}
