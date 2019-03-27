using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddConfigTableAndRemoveOTrainingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OTraining");

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<byte>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.CreateTable(
                name: "OTraining",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ForJoin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTraining", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 26, 20, 2, 17, 199, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 26, 20, 2, 17, 214, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 26, 20, 2, 17, 214, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 108, 98, 244, 11, 118, 60, 28, 62, 142, 10, 169, 112, 109, 52, 158, 164, 120, 186, 166, 162, 83, 44, 67, 121, 254, 32, 162, 218, 209, 216, 255, 113, 185, 213, 63, 15, 102, 186, 142, 41, 93, 101, 216, 149, 165, 107, 255, 59, 237, 179, 186, 211, 140, 169, 178, 161, 125, 84, 44, 73, 73, 227, 135, 147 }, new byte[] { 111, 211, 53, 173, 34, 74, 226, 183, 142, 138, 124, 108, 201, 189, 82, 43, 111, 142, 110, 184, 173, 191, 76, 223, 100, 177, 189, 3, 98, 84, 117, 223, 181, 188, 66, 179, 30, 187, 159, 121, 94, 164, 157, 162, 250, 55, 183, 8, 112, 73, 15, 111, 167, 90, 94, 204, 158, 204, 20, 12, 170, 116, 253, 192, 189, 111, 228, 110, 220, 178, 251, 105, 19, 34, 139, 223, 100, 64, 46, 62, 242, 230, 206, 190, 169, 173, 30, 39, 106, 44, 180, 29, 188, 173, 81, 6, 191, 213, 3, 95, 169, 160, 93, 173, 249, 11, 52, 138, 125, 109, 182, 183, 78, 8, 11, 139, 1, 134, 109, 218, 103, 46, 165, 102, 200, 121, 174, 87 } });
        }
    }
}
