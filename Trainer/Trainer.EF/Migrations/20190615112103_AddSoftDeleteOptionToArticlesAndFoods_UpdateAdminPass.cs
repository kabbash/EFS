﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddSoftDeleteOptionToArticlesAndFoods_UpdateAdminPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "FoodItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Articles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt", "PhoneNumber" },
                values: new object[] { new byte[] { 30, 70, 157, 67, 45, 203, 210, 46, 14, 90, 252, 100, 189, 226, 130, 111, 124, 47, 74, 6, 75, 155, 14, 215, 140, 204, 235, 121, 213, 211, 132, 105, 4, 142, 236, 233, 87, 135, 61, 247, 0, 61, 77, 78, 139, 38, 219, 6, 78, 165, 249, 114, 177, 124, 69, 190, 145, 250, 183, 209, 252, 103, 143, 70 }, new byte[] { 18, 70, 94, 83, 173, 208, 15, 196, 103, 250, 236, 88, 154, 163, 98, 73, 229, 21, 16, 144, 187, 219, 168, 171, 7, 30, 37, 174, 1, 42, 20, 139, 252, 25, 153, 28, 146, 159, 97, 5, 167, 30, 134, 60, 54, 208, 16, 93, 116, 144, 27, 167, 151, 224, 135, 71, 165, 213, 53, 110, 112, 74, 206, 120, 215, 154, 92, 69, 247, 184, 72, 88, 215, 232, 12, 176, 182, 121, 215, 95, 232, 233, 66, 251, 241, 114, 163, 84, 16, 1, 15, 142, 88, 143, 197, 204, 182, 161, 84, 147, 122, 65, 236, 98, 39, 248, 233, 203, 46, 23, 98, 210, 109, 53, 136, 199, 180, 220, 17, 225, 159, 155, 14, 144, 142, 190, 123, 32 }, "01097976064" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "948f5fb5-00ce-4d61-9e4b-741290e20024",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 230, 16, 166, 108, 195, 176, 33, 88, 237, 119, 147, 55, 79, 181, 174, 99, 214, 210, 205, 161, 9, 114, 109, 199, 134, 210, 77, 13, 227, 204, 150, 82, 195, 237, 15, 180, 206, 130, 138, 21, 29, 58, 64, 9, 94, 142, 68, 229, 145, 105, 36, 89, 170, 75, 208, 53, 103, 160, 172, 254, 170, 206, 89, 29 }, new byte[] { 18, 70, 94, 83, 173, 208, 15, 196, 103, 250, 236, 88, 154, 163, 98, 73, 229, 21, 16, 144, 187, 219, 168, 171, 7, 30, 37, 174, 1, 42, 20, 139, 252, 25, 153, 28, 146, 159, 97, 5, 167, 30, 134, 60, 54, 208, 16, 93, 116, 144, 27, 167, 151, 224, 135, 71, 165, 213, 53, 110, 112, 74, 206, 120, 215, 154, 92, 69, 247, 184, 72, 88, 215, 232, 12, 176, 182, 121, 215, 95, 232, 233, 66, 251, 241, 114, 163, 84, 16, 1, 15, 142, 88, 143, 197, 204, 182, 161, 84, 147, 122, 65, 236, 98, 39, 248, 233, 203, 46, 23, 98, 210, 109, 53, 136, 199, 180, 220, 17, 225, 159, 155, 14, 144, 142, 190, 123, 32 } });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b62f98ba-68ea-45d0-8209-48ee24d40e53",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 230, 16, 166, 108, 195, 176, 33, 88, 237, 119, 147, 55, 79, 181, 174, 99, 214, 210, 205, 161, 9, 114, 109, 199, 134, 210, 77, 13, 227, 204, 150, 82, 195, 237, 15, 180, 206, 130, 138, 21, 29, 58, 64, 9, 94, 142, 68, 229, 145, 105, 36, 89, 170, 75, 208, 53, 103, 160, 172, 254, 170, 206, 89, 29 }, new byte[] { 18, 70, 94, 83, 173, 208, 15, 196, 103, 250, 236, 88, 154, 163, 98, 73, 229, 21, 16, 144, 187, 219, 168, 171, 7, 30, 37, 174, 1, 42, 20, 139, 252, 25, 153, 28, 146, 159, 97, 5, 167, 30, 134, 60, 54, 208, 16, 93, 116, 144, 27, 167, 151, 224, 135, 71, 165, 213, 53, 110, 112, 74, 206, 120, 215, 154, 92, 69, 247, 184, 72, 88, 215, 232, 12, 176, 182, 121, 215, 95, 232, 233, 66, 251, 241, 114, 163, 84, 16, 1, 15, 142, 88, 143, 197, 204, 182, 161, 84, 147, 122, 65, 236, 98, 39, 248, 233, 203, 46, 23, 98, 210, 109, 53, 136, 199, 180, 220, 17, 225, 159, 155, 14, 144, 142, 190, 123, 32 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt", "PhoneNumber" },
                values: new object[] { new byte[] { 42, 239, 163, 106, 200, 213, 171, 17, 175, 247, 159, 124, 176, 38, 57, 220, 225, 58, 10, 123, 36, 48, 38, 145, 61, 220, 53, 83, 107, 47, 213, 122, 219, 191, 185, 32, 178, 250, 203, 32, 237, 35, 212, 5, 131, 117, 18, 106, 72, 219, 32, 189, 215, 71, 240, 218, 178, 66, 48, 24, 228, 220, 234, 69 }, new byte[] { 44, 106, 207, 208, 221, 217, 115, 182, 175, 97, 6, 242, 76, 200, 68, 212, 114, 212, 54, 102, 100, 219, 189, 82, 241, 36, 186, 68, 248, 8, 5, 177, 165, 186, 206, 109, 168, 201, 28, 233, 180, 27, 68, 156, 214, 118, 93, 77, 30, 79, 106, 98, 4, 117, 153, 80, 212, 118, 102, 206, 16, 229, 144, 127, 69, 49, 221, 206, 249, 229, 230, 84, 74, 178, 185, 85, 59, 117, 106, 117, 23, 34, 137, 216, 81, 67, 241, 16, 130, 38, 17, 67, 42, 152, 238, 10, 198, 179, 159, 156, 175, 111, 76, 220, 31, 36, 206, 208, 127, 121, 0, 178, 140, 41, 177, 74, 202, 188, 82, 213, 60, 246, 243, 54, 177, 155, 10, 241 }, "01012345678" });

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
    }
}
