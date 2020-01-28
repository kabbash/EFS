using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddMissingFoodItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "alanine",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "argnine",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "asparticAcid",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "chromuim",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "florid",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "glotamicAcid",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "glycine",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "hydroxiplorien",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "moly",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "proline",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "serine",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "yod",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 5, 27, 18, 43, 0, 743, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 5, 27, 18, 43, 0, 747, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 5, 27, 18, 43, 0, 747, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 212, 53, 127, 155, 41, 177, 176, 192, 194, 92, 50, 243, 221, 202, 127, 251, 82, 12, 218, 198, 202, 127, 43, 164, 22, 69, 107, 177, 248, 223, 165, 115, 13, 139, 106, 41, 227, 16, 124, 192, 122, 99, 55, 66, 64, 116, 100, 99, 2, 83, 131, 142, 118, 114, 98, 251, 102, 101, 221, 203, 54, 234, 201 }, new byte[] { 146, 140, 73, 165, 64, 26, 211, 28, 196, 92, 73, 24, 185, 248, 230, 110, 247, 103, 46, 150, 163, 95, 11, 90, 112, 169, 171, 4, 72, 84, 104, 202, 163, 168, 37, 159, 63, 51, 81, 21, 27, 79, 186, 89, 50, 121, 73, 111, 154, 51, 37, 63, 136, 206, 30, 67, 120, 4, 37, 51, 16, 254, 23, 85, 146, 187, 108, 7, 167, 78, 81, 131, 40, 38, 195, 14, 72, 191, 175, 134, 46, 249, 114, 107, 176, 121, 179, 145, 1, 166, 29, 174, 15, 102, 157, 119, 175, 228, 31, 62, 235, 162, 76, 253, 229, 45, 51, 40, 209, 128, 235, 43, 243, 126, 127, 198, 153, 194, 81, 36, 120, 249, 199, 77, 33, 57, 14, 180 } });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "948f5fb5-00ce-4d61-9e4b-741290e20024",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 212, 53, 127, 155, 41, 177, 176, 192, 194, 92, 50, 243, 221, 202, 127, 251, 82, 12, 218, 198, 202, 127, 43, 164, 22, 69, 107, 177, 248, 223, 165, 115, 13, 139, 106, 41, 227, 16, 124, 192, 122, 99, 55, 66, 64, 116, 100, 99, 2, 83, 131, 142, 118, 114, 98, 251, 102, 101, 221, 203, 54, 234, 201 }, new byte[] { 146, 140, 73, 165, 64, 26, 211, 28, 196, 92, 73, 24, 185, 248, 230, 110, 247, 103, 46, 150, 163, 95, 11, 90, 112, 169, 171, 4, 72, 84, 104, 202, 163, 168, 37, 159, 63, 51, 81, 21, 27, 79, 186, 89, 50, 121, 73, 111, 154, 51, 37, 63, 136, 206, 30, 67, 120, 4, 37, 51, 16, 254, 23, 85, 146, 187, 108, 7, 167, 78, 81, 131, 40, 38, 195, 14, 72, 191, 175, 134, 46, 249, 114, 107, 176, 121, 179, 145, 1, 166, 29, 174, 15, 102, 157, 119, 175, 228, 31, 62, 235, 162, 76, 253, 229, 45, 51, 40, 209, 128, 235, 43, 243, 126, 127, 198, 153, 194, 81, 36, 120, 249, 199, 77, 33, 57, 14, 180 } });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b62f98ba-68ea-45d0-8209-48ee24d40e53",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 222, 212, 53, 127, 155, 41, 177, 176, 192, 194, 92, 50, 243, 221, 202, 127, 251, 82, 12, 218, 198, 202, 127, 43, 164, 22, 69, 107, 177, 248, 223, 165, 115, 13, 139, 106, 41, 227, 16, 124, 192, 122, 99, 55, 66, 64, 116, 100, 99, 2, 83, 131, 142, 118, 114, 98, 251, 102, 101, 221, 203, 54, 234, 201 }, new byte[] { 146, 140, 73, 165, 64, 26, 211, 28, 196, 92, 73, 24, 185, 248, 230, 110, 247, 103, 46, 150, 163, 95, 11, 90, 112, 169, 171, 4, 72, 84, 104, 202, 163, 168, 37, 159, 63, 51, 81, 21, 27, 79, 186, 89, 50, 121, 73, 111, 154, 51, 37, 63, 136, 206, 30, 67, 120, 4, 37, 51, 16, 254, 23, 85, 146, 187, 108, 7, 167, 78, 81, 131, 40, 38, 195, 14, 72, 191, 175, 134, 46, 249, 114, 107, 176, 121, 179, 145, 1, 166, 29, 174, 15, 102, 157, 119, 175, 228, 31, 62, 235, 162, 76, 253, 229, 45, 51, 40, 209, 128, 235, 43, 243, 126, 127, 198, 153, 194, 81, 36, 120, 249, 199, 77, 33, 57, 14, 180 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alanine",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "argnine",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "asparticAcid",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "chromuim",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "florid",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "glotamicAcid",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "glycine",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "hydroxiplorien",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "moly",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "proline",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "serine",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "yod",
                table: "FoodItems");

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 4, 22, 18, 28, 53, 950, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 4, 22, 18, 28, 53, 951, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 4, 22, 18, 28, 53, 951, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 81, 181, 173, 214, 195, 26, 97, 151, 21, 21, 216, 130, 99, 245, 159, 134, 127, 36, 76, 52, 36, 172, 169, 204, 85, 246, 49, 119, 158, 186, 86, 148, 140, 147, 186, 12, 67, 221, 63, 76, 252, 65, 25, 116, 199, 64, 14, 74, 211, 32, 241, 47, 127, 238, 8, 252, 186, 216, 222, 7, 177, 29, 85, 41 }, new byte[] { 201, 218, 128, 197, 83, 47, 250, 252, 31, 195, 39, 140, 146, 26, 147, 109, 83, 8, 1, 54, 13, 34, 214, 90, 49, 132, 92, 64, 90, 182, 46, 216, 190, 16, 203, 102, 100, 104, 136, 139, 149, 26, 65, 88, 103, 253, 236, 131, 67, 39, 145, 75, 71, 9, 10, 115, 211, 146, 199, 111, 96, 59, 187, 5, 19, 18, 73, 218, 62, 35, 159, 142, 115, 26, 196, 82, 42, 23, 76, 228, 47, 43, 254, 108, 163, 236, 1, 37, 221, 35, 121, 42, 175, 138, 44, 254, 81, 232, 203, 175, 118, 0, 213, 243, 186, 190, 246, 135, 114, 211, 139, 104, 97, 238, 148, 215, 85, 79, 76, 51, 228, 194, 206, 169, 169, 217, 98, 45 } });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "948f5fb5-00ce-4d61-9e4b-741290e20024",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 81, 181, 173, 214, 195, 26, 97, 151, 21, 21, 216, 130, 99, 245, 159, 134, 127, 36, 76, 52, 36, 172, 169, 204, 85, 246, 49, 119, 158, 186, 86, 148, 140, 147, 186, 12, 67, 221, 63, 76, 252, 65, 25, 116, 199, 64, 14, 74, 211, 32, 241, 47, 127, 238, 8, 252, 186, 216, 222, 7, 177, 29, 85, 41 }, new byte[] { 201, 218, 128, 197, 83, 47, 250, 252, 31, 195, 39, 140, 146, 26, 147, 109, 83, 8, 1, 54, 13, 34, 214, 90, 49, 132, 92, 64, 90, 182, 46, 216, 190, 16, 203, 102, 100, 104, 136, 139, 149, 26, 65, 88, 103, 253, 236, 131, 67, 39, 145, 75, 71, 9, 10, 115, 211, 146, 199, 111, 96, 59, 187, 5, 19, 18, 73, 218, 62, 35, 159, 142, 115, 26, 196, 82, 42, 23, 76, 228, 47, 43, 254, 108, 163, 236, 1, 37, 221, 35, 121, 42, 175, 138, 44, 254, 81, 232, 203, 175, 118, 0, 213, 243, 186, 190, 246, 135, 114, 211, 139, 104, 97, 238, 148, 215, 85, 79, 76, 51, 228, 194, 206, 169, 169, 217, 98, 45 } });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b62f98ba-68ea-45d0-8209-48ee24d40e53",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 81, 181, 173, 214, 195, 26, 97, 151, 21, 21, 216, 130, 99, 245, 159, 134, 127, 36, 76, 52, 36, 172, 169, 204, 85, 246, 49, 119, 158, 186, 86, 148, 140, 147, 186, 12, 67, 221, 63, 76, 252, 65, 25, 116, 199, 64, 14, 74, 211, 32, 241, 47, 127, 238, 8, 252, 186, 216, 222, 7, 177, 29, 85, 41 }, new byte[] { 201, 218, 128, 197, 83, 47, 250, 252, 31, 195, 39, 140, 146, 26, 147, 109, 83, 8, 1, 54, 13, 34, 214, 90, 49, 132, 92, 64, 90, 182, 46, 216, 190, 16, 203, 102, 100, 104, 136, 139, 149, 26, 65, 88, 103, 253, 236, 131, 67, 39, 145, 75, 71, 9, 10, 115, 211, 146, 199, 111, 96, 59, 187, 5, 19, 18, 73, 218, 62, 35, 159, 142, 115, 26, 196, 82, 42, 23, 76, 228, 47, 43, 254, 108, 163, 236, 1, 37, 221, 35, 121, 42, 175, 138, 44, 254, 81, 232, 203, 175, 118, 0, 213, 243, 186, 190, 246, 135, 114, 211, 139, 104, 97, 238, 148, 215, 85, 79, 76, 51, 228, 194, 206, 169, 169, 217, 98, 45 } });
        }
    }
}
