using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddBannerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ButtonUrl = table.Column<string>(nullable: true),
                    ButtonText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

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
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 255, 19, 248, 39, 215, 78, 44, 34, 64, 157, 124, 101, 111, 204, 83, 237, 199, 122, 193, 40, 68, 29, 240, 65, 216, 98, 102, 161, 214, 24, 242, 88, 149, 233, 252, 98, 6, 98, 77, 90, 23, 49, 110, 44, 164, 13, 79, 55, 52, 170, 172, 62, 163, 14, 175, 205, 169, 20, 132, 51, 20, 69, 234, 241 }, new byte[] { 168, 34, 141, 233, 106, 64, 18, 247, 32, 199, 185, 222, 53, 47, 230, 229, 192, 217, 60, 46, 215, 160, 224, 17, 217, 64, 244, 219, 161, 132, 56, 69, 228, 92, 58, 59, 118, 33, 126, 5, 167, 204, 92, 88, 163, 44, 94, 45, 19, 121, 254, 119, 239, 20, 253, 248, 128, 76, 223, 40, 170, 252, 141, 26, 200, 188, 19, 68, 154, 183, 80, 147, 154, 189, 92, 32, 236, 65, 98, 116, 154, 193, 190, 134, 38, 52, 141, 60, 130, 84, 249, 162, 129, 120, 54, 125, 3, 71, 160, 36, 110, 151, 232, 2, 245, 213, 211, 236, 35, 33, 155, 125, 70, 40, 218, 3, 221, 124, 237, 236, 168, 216, 80, 62, 37, 174, 134, 80 } });
        }
    }
}
