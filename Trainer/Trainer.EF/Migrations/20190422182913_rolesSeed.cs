using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class rolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Email", "FullName", "PasswordHash", "PasswordSalt", "PhoneNumber", "UserName" },
                values: new object[] { "admin@efs.com", "admin", new byte[] { 81, 181, 173, 214, 195, 26, 97, 151, 21, 21, 216, 130, 99, 245, 159, 134, 127, 36, 76, 52, 36, 172, 169, 204, 85, 246, 49, 119, 158, 186, 86, 148, 140, 147, 186, 12, 67, 221, 63, 76, 252, 65, 25, 116, 199, 64, 14, 74, 211, 32, 241, 47, 127, 238, 8, 252, 186, 216, 222, 7, 177, 29, 85, 41 }, new byte[] { 201, 218, 128, 197, 83, 47, 250, 252, 31, 195, 39, 140, 146, 26, 147, 109, 83, 8, 1, 54, 13, 34, 214, 90, 49, 132, 92, 64, 90, 182, 46, 216, 190, 16, 203, 102, 100, 104, 136, 139, 149, 26, 65, 88, 103, 253, 236, 131, 67, 39, 145, 75, 71, 9, 10, 115, 211, 146, 199, 111, 96, 59, 187, 5, 19, 18, 73, 218, 62, 35, 159, 142, 115, 26, 196, 82, 42, 23, 76, 228, 47, 43, 254, 108, 163, 236, 1, 37, 221, 35, 121, 42, 175, 138, 44, 254, 81, 232, 203, 175, 118, 0, 213, 243, 186, 190, 246, 135, 114, 211, 139, 104, 97, 238, 148, 215, 85, 79, 76, 51, 228, 194, 206, 169, 169, 217, 98, 45 }, "01012345678", "admin@efs.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Email", "EmailConfirmed", "FullName", "Hometown", "IsBlocked", "LockoutEnabled", "LockoutEndDateUtc", "PasswordHash", "PasswordSalt", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "948f5fb5-00ce-4d61-9e4b-741290e20024", 0, "writer@efs.com", true, "articles writer", null, false, false, null, new byte[] { 81, 181, 173, 214, 195, 26, 97, 151, 21, 21, 216, 130, 99, 245, 159, 134, 127, 36, 76, 52, 36, 172, 169, 204, 85, 246, 49, 119, 158, 186, 86, 148, 140, 147, 186, 12, 67, 221, 63, 76, 252, 65, 25, 116, 199, 64, 14, 74, 211, 32, 241, 47, 127, 238, 8, 252, 186, 216, 222, 7, 177, 29, 85, 41 }, new byte[] { 201, 218, 128, 197, 83, 47, 250, 252, 31, 195, 39, 140, 146, 26, 147, 109, 83, 8, 1, 54, 13, 34, 214, 90, 49, 132, 92, 64, 90, 182, 46, 216, 190, 16, 203, 102, 100, 104, 136, 139, 149, 26, 65, 88, 103, 253, 236, 131, 67, 39, 145, 75, 71, 9, 10, 115, 211, 146, 199, 111, 96, 59, 187, 5, 19, 18, 73, 218, 62, 35, 159, 142, 115, 26, 196, 82, 42, 23, 76, 228, 47, 43, 254, 108, 163, 236, 1, 37, 221, 35, 121, 42, 175, 138, 44, 254, 81, 232, 203, 175, 118, 0, 213, 243, 186, 190, 246, 135, 114, 211, 139, 104, 97, 238, 148, 215, 85, 79, 76, 51, 228, 194, 206, 169, 169, 217, 98, 45 }, "01012345678", false, null, null, false, "writer@gmail.com" },
                    { "b62f98ba-68ea-45d0-8209-48ee24d40e53", 0, "user@efs.com", true, "regular user", null, false, false, null, new byte[] { 81, 181, 173, 214, 195, 26, 97, 151, 21, 21, 216, 130, 99, 245, 159, 134, 127, 36, 76, 52, 36, 172, 169, 204, 85, 246, 49, 119, 158, 186, 86, 148, 140, 147, 186, 12, 67, 221, 63, 76, 252, 65, 25, 116, 199, 64, 14, 74, 211, 32, 241, 47, 127, 238, 8, 252, 186, 216, 222, 7, 177, 29, 85, 41 }, new byte[] { 201, 218, 128, 197, 83, 47, 250, 252, 31, 195, 39, 140, 146, 26, 147, 109, 83, 8, 1, 54, 13, 34, 214, 90, 49, 132, 92, 64, 90, 182, 46, 216, 190, 16, 203, 102, 100, 104, 136, 139, 149, 26, 65, 88, 103, 253, 236, 131, 67, 39, 145, 75, 71, 9, 10, 115, 211, 146, 199, 111, 96, 59, 187, 5, 19, 18, 73, 218, 62, 35, 159, 142, 115, 26, 196, 82, 42, 23, 76, 228, 47, 43, 254, 108, 163, 236, 1, 37, 221, 35, 121, 42, 175, 138, 44, 254, 81, 232, 203, 175, 118, 0, 213, 243, 186, 190, 246, 135, 114, 211, 139, 104, 97, 238, 148, 215, 85, 79, 76, 51, 228, 194, 206, 169, 169, 217, 98, 45 }, "01012345678", false, null, null, false, "user@efs.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "948f5fb5-00ce-4d61-9e4b-741290e20024", "6a883f63-ef24-4693-a10f-ac30aaca972e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b62f98ba-68ea-45d0-8209-48ee24d40e53", "07ab2dd0-83e1-49a4-a8dc-66d948355392" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "948f5fb5-00ce-4d61-9e4b-741290e20024", "6a883f63-ef24-4693-a10f-ac30aaca972e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b62f98ba-68ea-45d0-8209-48ee24d40e53", "07ab2dd0-83e1-49a4-a8dc-66d948355392" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "948f5fb5-00ce-4d61-9e4b-741290e20024");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b62f98ba-68ea-45d0-8209-48ee24d40e53");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "b3c0d399-61f6-47e1-99eb-c545052992d6", "Trainee" },
                    { "7c433dc0-d62b-43da-91d5-5b63e41a902f", "Food Articles Writer" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "Email", "FullName", "PasswordHash", "PasswordSalt", "PhoneNumber", "UserName" },
                values: new object[] { "ahmedkabbash@gmail.com", "ahmed kabbash", new byte[] { 4, 65, 24, 192, 10, 162, 96, 15, 28, 222, 115, 106, 242, 57, 210, 231, 66, 98, 235, 152, 189, 173, 197, 111, 212, 12, 7, 252, 85, 93, 152, 70, 158, 22, 228, 20, 151, 157, 152, 166, 22, 158, 255, 89, 57, 198, 214, 244, 238, 49, 114, 93, 76, 98, 151, 213, 95, 81, 144, 251, 46, 24, 5, 151 }, new byte[] { 234, 62, 250, 21, 226, 156, 0, 204, 245, 214, 85, 196, 228, 59, 204, 44, 196, 102, 44, 251, 15, 134, 17, 195, 207, 188, 47, 160, 179, 99, 19, 184, 236, 214, 20, 57, 76, 0, 108, 113, 9, 84, 49, 153, 78, 131, 117, 219, 91, 93, 23, 241, 55, 118, 249, 183, 208, 151, 76, 240, 196, 44, 87, 12, 51, 53, 94, 89, 66, 45, 161, 156, 8, 220, 173, 221, 211, 222, 164, 72, 192, 105, 162, 105, 138, 117, 54, 154, 161, 223, 52, 96, 60, 21, 238, 13, 94, 35, 235, 196, 16, 225, 21, 170, 245, 125, 206, 162, 226, 228, 166, 102, 174, 28, 7, 50, 146, 229, 84, 15, 99, 47, 187, 144, 203, 109, 234, 156 }, "01014991554", "ahmedkabbash@gmail.com" });
        }
    }
}
