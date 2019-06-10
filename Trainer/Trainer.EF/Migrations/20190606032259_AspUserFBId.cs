﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AspUserFBId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 6, 6, 3, 22, 54, 884, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 6, 6, 3, 22, 54, 898, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 6, 6, 3, 22, 54, 898, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 239, 163, 106, 200, 213, 171, 17, 175, 247, 159, 124, 176, 38, 57, 220, 225, 58, 10, 123, 36, 48, 38, 145, 61, 220, 53, 83, 107, 47, 213, 122, 219, 191, 185, 32, 178, 250, 203, 32, 237, 35, 212, 5, 131, 117, 18, 106, 72, 219, 32, 189, 215, 71, 240, 218, 178, 66, 48, 24, 228, 220, 234, 69 }, new byte[] { 44, 106, 207, 208, 221, 217, 115, 182, 175, 97, 6, 242, 76, 200, 68, 212, 114, 212, 54, 102, 100, 219, 189, 82, 241, 36, 186, 68, 248, 8, 5, 177, 165, 186, 206, 109, 168, 201, 28, 233, 180, 27, 68, 156, 214, 118, 93, 77, 30, 79, 106, 98, 4, 117, 153, 80, 212, 118, 102, 206, 16, 229, 144, 127, 69, 49, 221, 206, 249, 229, 230, 84, 74, 178, 185, 85, 59, 117, 106, 117, 23, 34, 137, 216, 81, 67, 241, 16, 130, 38, 17, 67, 42, 152, 238, 10, 198, 179, 159, 156, 175, 111, 76, 220, 31, 36, 206, 208, 127, 121, 0, 178, 140, 41, 177, 74, 202, 188, 82, 213, 60, 246, 243, 54, 177, 155, 10, 241 } });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "948f5fb5-00ce-4d61-9e4b-741290e20024",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 239, 163, 106, 200, 213, 171, 17, 175, 247, 159, 124, 176, 38, 57, 220, 225, 58, 10, 123, 36, 48, 38, 145, 61, 220, 53, 83, 107, 47, 213, 122, 219, 191, 185, 32, 178, 250, 203, 32, 237, 35, 212, 5, 131, 117, 18, 106, 72, 219, 32, 189, 215, 71, 240, 218, 178, 66, 48, 24, 228, 220, 234, 69 }, new byte[] { 44, 106, 207, 208, 221, 217, 115, 182, 175, 97, 6, 242, 76, 200, 68, 212, 114, 212, 54, 102, 100, 219, 189, 82, 241, 36, 186, 68, 248, 8, 5, 177, 165, 186, 206, 109, 168, 201, 28, 233, 180, 27, 68, 156, 214, 118, 93, 77, 30, 79, 106, 98, 4, 117, 153, 80, 212, 118, 102, 206, 16, 229, 144, 127, 69, 49, 221, 206, 249, 229, 230, 84, 74, 178, 185, 85, 59, 117, 106, 117, 23, 34, 137, 216, 81, 67, 241, 16, 130, 38, 17, 67, 42, 152, 238, 10, 198, 179, 159, 156, 175, 111, 76, 220, 31, 36, 206, 208, 127, 121, 0, 178, 140, 41, 177, 74, 202, 188, 82, 213, 60, 246, 243, 54, 177, 155, 10, 241 } });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b62f98ba-68ea-45d0-8209-48ee24d40e53",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 239, 163, 106, 200, 213, 171, 17, 175, 247, 159, 124, 176, 38, 57, 220, 225, 58, 10, 123, 36, 48, 38, 145, 61, 220, 53, 83, 107, 47, 213, 122, 219, 191, 185, 32, 178, 250, 203, 32, 237, 35, 212, 5, 131, 117, 18, 106, 72, 219, 32, 189, 215, 71, 240, 218, 178, 66, 48, 24, 228, 220, 234, 69 }, new byte[] { 44, 106, 207, 208, 221, 217, 115, 182, 175, 97, 6, 242, 76, 200, 68, 212, 114, 212, 54, 102, 100, 219, 189, 82, 241, 36, 186, 68, 248, 8, 5, 177, 165, 186, 206, 109, 168, 201, 28, 233, 180, 27, 68, 156, 214, 118, 93, 77, 30, 79, 106, 98, 4, 117, 153, 80, 212, 118, 102, 206, 16, 229, 144, 127, 69, 49, 221, 206, 249, 229, 230, 84, 74, 178, 185, 85, 59, 117, 106, 117, 23, 34, 137, 216, 81, 67, 241, 16, 130, 38, 17, 67, 42, 152, 238, 10, 198, 179, 159, 156, 175, 111, 76, 220, 31, 36, 206, 208, 127, 121, 0, 178, 140, 41, 177, 74, 202, 188, 82, 213, 60, 246, 243, 54, 177, 155, 10, 241 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookId",
                table: "AspNetUsers");

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
