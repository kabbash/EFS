using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class EfsRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ccca260-6ccf-44ac-905c-0d74012eebe9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22960cdb-67e6-4f27-8d30-511d0779ee70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57d360b8-d4d5-4f53-825c-6df2f1770977");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee7a9ba-79ab-4041-a758-ab7a879d01b4");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 13, 19, 40, 40, 196, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 13, 19, 40, 40, 197, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "b3c0d399-61f6-47e1-99eb-c545052992d6", "Trainee" },
                    { "07ab2dd0-83e1-49a4-a8dc-66d948355392", "Regular User" },
                    { "7c433dc0-d62b-43da-91d5-5b63e41a902f", "Food Articles Writer" },
                    { "6a883f63-ef24-4693-a10f-ac30aaca972e", "Articles Writer" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 142, 87, 194, 124, 207, 137, 75, 68, 209, 73, 45, 105, 229, 146, 184, 185, 115, 3, 33, 19, 7, 176, 202, 38, 245, 221, 181, 31, 234, 217, 207, 178, 239, 56, 52, 117, 142, 224, 253, 223, 42, 47, 69, 226, 7, 221, 81, 198, 136, 157, 194, 100, 175, 177, 170, 132, 35, 159, 63, 80, 204, 181, 121, 187 }, new byte[] { 133, 164, 246, 65, 8, 144, 27, 156, 152, 75, 58, 17, 153, 63, 155, 79, 128, 76, 87, 98, 181, 177, 172, 253, 135, 62, 86, 223, 187, 54, 235, 78, 179, 130, 168, 157, 127, 34, 62, 140, 12, 100, 155, 190, 15, 29, 126, 58, 103, 60, 152, 193, 79, 4, 74, 170, 110, 76, 32, 7, 44, 247, 125, 183, 233, 44, 150, 147, 81, 162, 51, 226, 249, 138, 186, 81, 158, 58, 161, 2, 140, 67, 215, 245, 216, 129, 178, 164, 40, 113, 180, 167, 98, 74, 234, 154, 195, 24, 66, 19, 172, 173, 202, 49, 124, 244, 148, 236, 241, 127, 184, 114, 17, 104, 26, 151, 168, 188, 96, 183, 188, 151, 147, 122, 226, 91, 212, 50 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07ab2dd0-83e1-49a4-a8dc-66d948355392");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a883f63-ef24-4693-a10f-ac30aaca972e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c433dc0-d62b-43da-91d5-5b63e41a902f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3c0d399-61f6-47e1-99eb-c545052992d6");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 13, 19, 34, 16, 703, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 13, 19, 34, 16, 758, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "22960cdb-67e6-4f27-8d30-511d0779ee70", "Client" },
                    { "57d360b8-d4d5-4f53-825c-6df2f1770977", "RegularUser" },
                    { "6ee7a9ba-79ab-4041-a758-ab7a879d01b4", "Trainer" },
                    { "0ccca260-6ccf-44ac-905c-0d74012eebe9", "ArticleWriter" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 132, 157, 48, 94, 197, 175, 206, 15, 163, 242, 153, 131, 165, 64, 78, 87, 50, 154, 9, 65, 161, 60, 31, 73, 131, 175, 73, 208, 112, 197, 164, 0, 69, 160, 185, 76, 59, 212, 34, 167, 48, 71, 45, 88, 229, 215, 54, 91, 2, 127, 189, 179, 233, 106, 6, 74, 90, 247, 243, 199, 117, 79, 54, 185 }, new byte[] { 191, 1, 158, 242, 122, 27, 241, 55, 99, 1, 249, 156, 119, 22, 166, 80, 153, 101, 131, 199, 237, 142, 182, 224, 60, 79, 234, 151, 176, 194, 154, 145, 41, 218, 171, 155, 204, 43, 79, 62, 58, 46, 131, 158, 242, 92, 145, 11, 119, 238, 80, 217, 146, 56, 204, 192, 228, 225, 117, 39, 255, 95, 151, 163, 183, 145, 216, 147, 134, 163, 106, 15, 188, 241, 38, 106, 37, 79, 253, 250, 24, 249, 147, 180, 159, 66, 202, 140, 186, 249, 209, 64, 114, 85, 244, 235, 188, 172, 106, 131, 239, 161, 51, 132, 124, 116, 37, 138, 3, 254, 8, 82, 213, 251, 255, 40, 181, 34, 238, 56, 81, 88, 32, 107, 93, 104, 31, 208 } });
        }
    }
}
