using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddFoodItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Calories = table.Column<decimal>(nullable: false),
                    Energy = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    Caffiene = table.Column<decimal>(nullable: false),
                    Water = table.Column<decimal>(nullable: false),
                    Carbs = table.Column<decimal>(nullable: false),
                    Fiber = table.Column<decimal>(nullable: false),
                    Starch = table.Column<decimal>(nullable: false),
                    Sugars = table.Column<decimal>(nullable: false),
                    NetCarbs = table.Column<decimal>(nullable: false),
                    Fat = table.Column<decimal>(nullable: false),
                    Monounsaturated = table.Column<decimal>(nullable: false),
                    Polyunsaturated = table.Column<decimal>(nullable: false),
                    Omega3 = table.Column<decimal>(nullable: false),
                    Omega6 = table.Column<decimal>(nullable: false),
                    Saturated = table.Column<decimal>(nullable: false),
                    TransFats = table.Column<decimal>(nullable: false),
                    Cholesterol = table.Column<decimal>(nullable: false),
                    Protein = table.Column<decimal>(nullable: false),
                    Cystine = table.Column<decimal>(nullable: false),
                    Histidine = table.Column<decimal>(nullable: false),
                    Isoleucine = table.Column<decimal>(nullable: false),
                    Leucine = table.Column<decimal>(nullable: false),
                    Lysine = table.Column<decimal>(nullable: false),
                    Methionine = table.Column<decimal>(nullable: false),
                    Phenylalanine = table.Column<decimal>(nullable: false),
                    Threonine = table.Column<decimal>(nullable: false),
                    Tryptophan = table.Column<decimal>(nullable: false),
                    Tyrosine = table.Column<decimal>(nullable: false),
                    Valine = table.Column<decimal>(nullable: false),
                    B1 = table.Column<decimal>(nullable: false),
                    B2 = table.Column<decimal>(nullable: false),
                    B3 = table.Column<decimal>(nullable: false),
                    B5 = table.Column<decimal>(nullable: false),
                    B6 = table.Column<decimal>(nullable: false),
                    B12 = table.Column<decimal>(nullable: false),
                    Folate = table.Column<decimal>(nullable: false),
                    VitaminA = table.Column<decimal>(nullable: false),
                    VitaminC = table.Column<decimal>(nullable: false),
                    VitaminD = table.Column<decimal>(nullable: false),
                    VitaminE = table.Column<decimal>(nullable: false),
                    VitaminK = table.Column<decimal>(nullable: false),
                    Calcuim = table.Column<decimal>(nullable: false),
                    Copper = table.Column<decimal>(nullable: false),
                    Iron = table.Column<decimal>(nullable: false),
                    Magnesium = table.Column<decimal>(nullable: false),
                    Manganese = table.Column<decimal>(nullable: false),
                    Phosphorus = table.Column<decimal>(nullable: false),
                    Potassium = table.Column<decimal>(nullable: false),
                    Selenium = table.Column<decimal>(nullable: false),
                    Sodium = table.Column<decimal>(nullable: false),
                    Zinc = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItems_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 19, 18, 48, 39, 665, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 19, 18, 48, 39, 668, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 137, 205, 209, 252, 122, 146, 218, 6, 238, 156, 141, 31, 15, 115, 143, 205, 53, 84, 74, 201, 80, 247, 66, 158, 91, 33, 145, 230, 186, 230, 87, 220, 47, 26, 154, 160, 15, 228, 188, 210, 108, 139, 166, 30, 34, 199, 165, 193, 168, 32, 162, 112, 156, 177, 238, 206, 151, 49, 159, 68, 71, 124, 182, 136 }, new byte[] { 204, 177, 11, 181, 44, 131, 74, 170, 79, 215, 218, 191, 135, 5, 5, 93, 149, 16, 138, 6, 119, 127, 206, 152, 62, 197, 149, 112, 164, 189, 126, 250, 14, 45, 46, 63, 22, 117, 219, 151, 236, 91, 228, 221, 252, 225, 226, 94, 35, 211, 176, 65, 157, 110, 220, 159, 218, 48, 22, 18, 94, 140, 251, 49, 138, 111, 172, 207, 163, 84, 163, 228, 200, 219, 94, 164, 180, 242, 254, 5, 180, 123, 45, 242, 30, 187, 137, 4, 248, 224, 92, 133, 138, 139, 127, 41, 212, 153, 6, 215, 124, 183, 75, 36, 6, 163, 255, 54, 250, 32, 17, 253, 45, 149, 43, 30, 227, 26, 86, 119, 184, 238, 62, 9, 94, 152, 9, 157 } });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_CreatedBy",
                table: "FoodItems",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 19, 18, 35, 32, 852, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 19, 18, 35, 32, 855, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 233, 4, 58, 193, 52, 205, 122, 46, 138, 36, 120, 88, 58, 140, 11, 148, 68, 233, 64, 8, 161, 191, 198, 171, 156, 245, 131, 164, 39, 87, 210, 213, 6, 66, 85, 185, 16, 16, 159, 115, 184, 44, 131, 201, 193, 171, 18, 46, 33, 192, 90, 208, 195, 149, 18, 53, 53, 18, 17, 36, 49, 129, 252, 44 }, new byte[] { 163, 244, 178, 22, 18, 162, 134, 211, 88, 133, 74, 217, 19, 10, 229, 19, 211, 77, 98, 23, 198, 133, 145, 220, 68, 237, 237, 191, 178, 221, 26, 63, 88, 224, 224, 71, 113, 202, 59, 44, 197, 60, 108, 100, 226, 25, 105, 14, 141, 201, 3, 40, 38, 143, 31, 163, 201, 183, 136, 34, 241, 200, 4, 231, 214, 201, 189, 225, 21, 217, 238, 127, 248, 143, 80, 128, 203, 98, 140, 128, 53, 204, 138, 0, 35, 166, 66, 241, 122, 237, 9, 220, 194, 200, 63, 215, 85, 129, 60, 100, 250, 123, 254, 99, 253, 41, 27, 103, 235, 191, 63, 246, 220, 153, 210, 196, 126, 28, 129, 13, 90, 255, 180, 89, 129, 211, 160, 238 } });
        }
    }
}
