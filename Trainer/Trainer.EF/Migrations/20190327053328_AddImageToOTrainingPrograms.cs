using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddImageToOTrainingPrograms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "OTrainingPrograms",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 27, 5, 33, 24, 630, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 27, 5, 33, 24, 637, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 27, 5, 33, 24, 637, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 230, 142, 177, 92, 114, 169, 241, 147, 125, 91, 136, 65, 68, 4, 153, 73, 125, 94, 151, 77, 203, 110, 118, 249, 96, 126, 95, 82, 53, 250, 238, 21, 51, 35, 118, 227, 90, 92, 142, 97, 62, 64, 201, 76, 10, 139, 206, 86, 161, 255, 114, 152, 89, 208, 59, 96, 153, 99, 159, 46, 79, 79, 163, 159 }, new byte[] { 46, 246, 159, 12, 112, 176, 229, 31, 106, 72, 162, 219, 42, 137, 57, 247, 123, 229, 145, 99, 49, 108, 60, 214, 151, 186, 71, 2, 119, 31, 36, 46, 84, 203, 122, 152, 157, 211, 87, 53, 162, 237, 89, 40, 231, 190, 48, 241, 92, 36, 180, 10, 152, 62, 22, 108, 109, 37, 72, 17, 232, 136, 194, 49, 47, 53, 251, 189, 232, 19, 70, 2, 24, 218, 88, 168, 44, 220, 119, 38, 180, 186, 177, 138, 193, 134, 164, 72, 189, 69, 245, 180, 9, 97, 180, 231, 243, 39, 119, 51, 33, 102, 193, 88, 185, 179, 121, 6, 44, 142, 196, 206, 104, 108, 223, 77, 206, 44, 236, 76, 225, 199, 11, 203, 220, 176, 14, 244 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "OTrainingPrograms");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 27, 5, 10, 20, 223, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 27, 5, 10, 20, 230, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 27, 5, 10, 20, 230, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 0, 120, 121, 33, 48, 129, 88, 39, 205, 17, 137, 35, 203, 19, 121, 39, 57, 221, 171, 232, 108, 59, 69, 12, 142, 174, 171, 178, 102, 40, 141, 220, 177, 252, 51, 18, 131, 114, 29, 53, 8, 195, 226, 110, 157, 37, 152, 40, 201, 196, 117, 138, 81, 78, 149, 25, 41, 179, 210, 117, 31, 211, 240, 231 }, new byte[] { 23, 55, 141, 104, 141, 104, 207, 239, 248, 82, 56, 69, 206, 20, 178, 166, 206, 192, 77, 94, 160, 230, 233, 36, 193, 50, 161, 225, 95, 162, 96, 130, 201, 171, 19, 22, 111, 111, 157, 179, 175, 173, 235, 23, 40, 90, 17, 162, 113, 101, 125, 160, 193, 84, 254, 161, 205, 102, 154, 73, 242, 255, 84, 67, 226, 116, 56, 62, 94, 21, 225, 241, 157, 122, 143, 106, 41, 108, 86, 37, 245, 62, 80, 23, 72, 245, 155, 132, 208, 71, 191, 203, 214, 129, 83, 164, 21, 185, 76, 79, 52, 76, 36, 202, 194, 156, 105, 17, 190, 119, 165, 217, 14, 48, 255, 169, 23, 46, 167, 79, 153, 28, 6, 165, 232, 84, 244, 233 } });
        }
    }
}
