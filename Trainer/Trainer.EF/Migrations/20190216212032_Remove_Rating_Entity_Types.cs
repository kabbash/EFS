using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class Remove_Rating_Entity_Types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityRatings_EntityTypes_EntityTypeId",
                table: "EntityRatings");

            migrationBuilder.DropTable(
                name: "EntityTypes");

            migrationBuilder.DropIndex(
                name: "IX_EntityRatings_EntityTypeId",
                table: "EntityRatings");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypes", x => x.Id);
                });

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 142, 87, 194, 124, 207, 137, 75, 68, 209, 73, 45, 105, 229, 146, 184, 185, 115, 3, 33, 19, 7, 176, 202, 38, 245, 221, 181, 31, 234, 217, 207, 178, 239, 56, 52, 117, 142, 224, 253, 223, 42, 47, 69, 226, 7, 221, 81, 198, 136, 157, 194, 100, 175, 177, 170, 132, 35, 159, 63, 80, 204, 181, 121, 187 }, new byte[] { 133, 164, 246, 65, 8, 144, 27, 156, 152, 75, 58, 17, 153, 63, 155, 79, 128, 76, 87, 98, 181, 177, 172, 253, 135, 62, 86, 223, 187, 54, 235, 78, 179, 130, 168, 157, 127, 34, 62, 140, 12, 100, 155, 190, 15, 29, 126, 58, 103, 60, 152, 193, 79, 4, 74, 170, 110, 76, 32, 7, 44, 247, 125, 183, 233, 44, 150, 147, 81, 162, 51, 226, 249, 138, 186, 81, 158, 58, 161, 2, 140, 67, 215, 245, 216, 129, 178, 164, 40, 113, 180, 167, 98, 74, 234, 154, 195, 24, 66, 19, 172, 173, 202, 49, 124, 244, 148, 236, 241, 127, 184, 114, 17, 104, 26, 151, 168, 188, 96, 183, 188, 151, 147, 122, 226, 91, 212, 50 } });

            migrationBuilder.InsertData(
                table: "EntityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "product" },
                    { 4, "hamda" },
                    { 9, "m7maaa ma7rooos" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityRatings_EntityTypeId",
                table: "EntityRatings",
                column: "EntityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRatings_EntityTypes_EntityTypeId",
                table: "EntityRatings",
                column: "EntityTypeId",
                principalTable: "EntityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
