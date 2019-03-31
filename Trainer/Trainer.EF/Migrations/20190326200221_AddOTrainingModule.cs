using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddOTrainingModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "OTrainingPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTrainingPrograms", x => x.Id);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OTraining");

            migrationBuilder.DropTable(
                name: "OTrainingPrograms");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 23, 17, 18, 11, 765, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 23, 17, 18, 11, 773, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 23, 17, 18, 11, 773, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 191, 201, 142, 127, 18, 78, 68, 77, 213, 242, 72, 185, 25, 201, 71, 81, 127, 62, 234, 91, 61, 73, 16, 244, 208, 16, 6, 14, 162, 9, 78, 131, 63, 152, 51, 236, 173, 100, 128, 221, 177, 176, 82, 125, 187, 232, 224, 137, 70, 96, 39, 238, 236, 198, 136, 174, 145, 42, 212, 17, 93, 208, 248, 223 }, new byte[] { 124, 246, 219, 2, 238, 220, 175, 172, 150, 185, 111, 40, 253, 184, 180, 200, 242, 58, 2, 102, 203, 69, 7, 121, 158, 134, 171, 11, 237, 245, 163, 154, 175, 48, 149, 150, 139, 238, 93, 218, 245, 209, 101, 138, 175, 157, 211, 246, 182, 168, 151, 6, 46, 108, 160, 214, 180, 211, 114, 147, 4, 78, 12, 179, 182, 111, 171, 55, 229, 26, 105, 226, 128, 130, 50, 220, 234, 104, 223, 237, 30, 105, 127, 51, 42, 207, 233, 10, 99, 133, 17, 242, 98, 3, 183, 199, 31, 227, 107, 8, 23, 55, 87, 180, 105, 45, 33, 252, 11, 196, 126, 5, 75, 29, 242, 231, 221, 195, 115, 204, 125, 69, 134, 189, 201, 223, 73, 166 } });
        }
    }
}
