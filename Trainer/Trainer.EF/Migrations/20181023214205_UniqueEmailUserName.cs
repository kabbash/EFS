using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class UniqueEmailUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2751a61a-89cd-4491-8849-0224e226cccd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c8dc9f2-810c-4282-8744-d339ce028204");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77ddd36b-f0ba-4587-8e47-6a7ed18ed487");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f8bb3ef-6ff6-4b2e-8d3c-dbea250b5bfc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "de32ca95-5bfe-4c54-bfc4-c899c4273733", "Admin" },
                    { "64dfc179-5ede-4ac3-a55f-f6b7bc45bf13", "Client" },
                    { "fe8823f8-9f24-4229-9e7e-76539677a298", "ProductOwner" },
                    { "df734017-2c9b-4821-82c3-3de4af5daedf", "RegularUser" },
                    { "d9d39ecb-1284-4ce8-ab95-d19d699041e8", "Trainer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Email", "EmailConfirmed", "FirstName", "Hometown", "LastName", "LockoutEnabled", "LockoutEndDateUtc", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f5eb3741-85a5-430e-a236-31105d860799", 0, "ahmedkabbash@gmail.com", true, "ahmed", null, "kabbash", false, null, "1234", null, false, null, null, false, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64dfc179-5ede-4ac3-a55f-f6b7bc45bf13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9d39ecb-1284-4ce8-ab95-d19d699041e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de32ca95-5bfe-4c54-bfc4-c899c4273733");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df734017-2c9b-4821-82c3-3de4af5daedf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe8823f8-9f24-4229-9e7e-76539677a298");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5eb3741-85a5-430e-a236-31105d860799");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3", "Admin" },
                    { "6c8dc9f2-810c-4282-8744-d339ce028204", "Client" },
                    { "9f8bb3ef-6ff6-4b2e-8d3c-dbea250b5bfc", "ProductOwner" },
                    { "77ddd36b-f0ba-4587-8e47-6a7ed18ed487", "RegularUser" },
                    { "2751a61a-89cd-4491-8849-0224e226cccd", "Trainer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Email", "EmailConfirmed", "FirstName", "Hometown", "LastName", "LockoutEnabled", "LockoutEndDateUtc", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7c654344-ad42-4428-a77a-00a8c1299c3f", 0, "ahmedkabbash@gmail.com", true, "ahmed", null, "kabbash", false, null, "1234", null, false, null, null, false, "Admin" });
        }
    }
}
