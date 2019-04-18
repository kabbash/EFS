using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddProductPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 4, 12, 15, 2, 2, 76, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 4, 12, 15, 2, 2, 110, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 4, 12, 15, 2, 2, 110, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 4, 65, 24, 192, 10, 162, 96, 15, 28, 222, 115, 106, 242, 57, 210, 231, 66, 98, 235, 152, 189, 173, 197, 111, 212, 12, 7, 252, 85, 93, 152, 70, 158, 22, 228, 20, 151, 157, 152, 166, 22, 158, 255, 89, 57, 198, 214, 244, 238, 49, 114, 93, 76, 98, 151, 213, 95, 81, 144, 251, 46, 24, 5, 151 }, new byte[] { 234, 62, 250, 21, 226, 156, 0, 204, 245, 214, 85, 196, 228, 59, 204, 44, 196, 102, 44, 251, 15, 134, 17, 195, 207, 188, 47, 160, 179, 99, 19, 184, 236, 214, 20, 57, 76, 0, 108, 113, 9, 84, 49, 153, 78, 131, 117, 219, 91, 93, 23, 241, 55, 118, 249, 183, 208, 151, 76, 240, 196, 44, 87, 12, 51, 53, 94, 89, 66, 45, 161, 156, 8, 220, 173, 221, 211, 222, 164, 72, 192, 105, 162, 105, 138, 117, 54, 154, 161, 223, 52, 96, 60, 21, 238, 13, 94, 35, 235, 196, 16, 225, 21, 170, 245, 125, 206, 162, 226, 228, 166, 102, 174, 28, 7, 50, 146, 229, 84, 15, 99, 47, 187, 144, 203, 109, 234, 156 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Products");

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
    }
}
