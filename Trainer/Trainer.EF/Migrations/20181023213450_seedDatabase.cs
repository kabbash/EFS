using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "7c654344-ad42-4428-a77a-00a8c1299c3f", 0, "ahmedkabbash@gmail.com", true, "ahmed", null, "kabbash", false, null,null, null, false, null, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns:new[] { "UserId", "RoleId" },
                values: new object[] { "7c654344-ad42-4428-a77a-00a8c1299c3f", "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
