using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class addingAdminRoleToUserAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0240e6ae-5098-45ee-baf4-4eb76e805ec9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "272e05d3-7035-4435-90eb-d08624f3c670");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9316308f-dd8a-4cfc-9390-2a3724ecb603");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa0fd9d9-0b39-4a32-85d2-0f629897f770");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f09fdda7-1200-4d01-aac8-e4631bb4420c");

            migrationBuilder.DeleteData(
               table: "AspNetUserRoles",
               keyColumn: "UserId",
               keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f");


            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "05ef3003-e275-480f-b35d-2c07fe539eec", "Client" },
                    { "ea7873ee-9e39-45e1-92cd-edfa5722684f", "ProductOwner" },
                    { "5e50f08e-7601-48d9-bbb7-a2f5a71dc264", "RegularUser" },
                    { "affb9f80-9a23-4390-a25a-e871fcb64b60", "Trainer" },
                    { "8053e39f-a18c-48b2-a147-6d4ac39147e2", "ArticleWriter" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7c654344-ad42-4428-a77a-00a8c1299c3f", "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05ef3003-e275-480f-b35d-2c07fe539eec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e50f08e-7601-48d9-bbb7-a2f5a71dc264");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8053e39f-a18c-48b2-a147-6d4ac39147e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "affb9f80-9a23-4390-a25a-e871fcb64b60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea7873ee-9e39-45e1-92cd-edfa5722684f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7c654344-ad42-4428-a77a-00a8c1299c3f", "1d2b6cf6-8e86-46e9-9df2-2cdfc8f906f3" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "9316308f-dd8a-4cfc-9390-2a3724ecb603", "Client" },
                    { "272e05d3-7035-4435-90eb-d08624f3c670", "ProductOwner" },
                    { "f09fdda7-1200-4d01-aac8-e4631bb4420c", "RegularUser" },
                    { "aa0fd9d9-0b39-4a32-85d2-0f629897f770", "Trainer" },
                    { "0240e6ae-5098-45ee-baf4-4eb76e805ec9", "ArticleWriter" }
                });
        }
    }
}
