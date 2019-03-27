using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class RemoveOnlineTrainingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "Calories");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropTable(
                name: "Clients_Documents");

            migrationBuilder.DropTable(
                name: "Clients_Images");

            migrationBuilder.DropTable(
                name: "Clients_Measurments");

            migrationBuilder.DropTable(
                name: "Clients_Overloads");

            migrationBuilder.DropTable(
                name: "Measurments");

            migrationBuilder.DropTable(
                name: "Overloads");

            migrationBuilder.DropTable(
                name: "Programs_Images");

            migrationBuilder.DropTable(
                name: "Programs_Prices");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Trainers_Programs");

            migrationBuilder.DropTable(
                name: "Trainers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "Calories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Place = table.Column<string>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_dbo.AspNetUsers",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    TypeId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Overloads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    TypeId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overloads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    Bio = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_dbo_AspNetUsers",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients_Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Path = table.Column<string>(nullable: false),
                    SentToClient = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Documents_Clients",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients_Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Path = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Images_Clients",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients_Measurments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    TypeId = table.Column<byte>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(8, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients_Measurments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Measurments_Clients",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients_Overloads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<string>(maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    TypeId = table.Column<byte>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(8, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients_Overloads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Overloads_Clients",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainers_Programs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ProfilePicture = table.Column<string>(nullable: false),
                    TrainerId = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_Programs_Trainers",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Programs_Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Images_Trainers_Programs",
                        column: x => x.ParentId,
                        principalTable: "Trainers_Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Programs_Prices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<string>(maxLength: 128, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    ProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Prices_Trainers_Programs",
                        column: x => x.ProgramId,
                        principalTable: "Trainers_Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 5, 19, 26, 47, 440, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 5, 19, 26, 47, 443, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Articles_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 3, 5, 19, 26, 47, 443, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c654344-ad42-4428-a77a-00a8c1299c3f",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 103, 13, 102, 122, 0, 123, 210, 79, 71, 52, 199, 182, 144, 142, 151, 123, 117, 16, 63, 134, 33, 156, 58, 43, 23, 90, 187, 33, 91, 100, 136, 178, 219, 251, 254, 254, 20, 24, 225, 64, 121, 110, 142, 147, 75, 33, 211, 20, 139, 175, 206, 151, 112, 192, 148, 101, 64, 53, 182, 253, 174, 74, 35, 146 }, new byte[] { 186, 251, 13, 151, 209, 120, 16, 95, 228, 154, 143, 11, 234, 20, 66, 128, 121, 155, 82, 149, 176, 147, 192, 79, 253, 221, 15, 254, 53, 17, 188, 139, 194, 223, 136, 89, 189, 95, 226, 173, 194, 164, 121, 130, 139, 240, 223, 248, 39, 84, 139, 77, 34, 163, 186, 131, 147, 242, 168, 119, 200, 62, 23, 2, 242, 30, 91, 30, 139, 173, 153, 79, 197, 102, 43, 53, 42, 10, 215, 83, 65, 60, 230, 194, 133, 104, 239, 62, 96, 246, 200, 165, 74, 227, 58, 236, 75, 70, 29, 150, 4, 208, 117, 46, 196, 67, 165, 127, 93, 245, 240, 175, 239, 163, 58, 4, 185, 68, 153, 198, 95, 186, 157, 253, 218, 189, 203, 70 } });

            migrationBuilder.CreateIndex(
                name: "IX_Calories_Name",
                table: "Calories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Documents_ClientID",
                table: "Clients_Documents",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Images_ClientId",
                table: "Clients_Images",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Measurments_ClientId",
                table: "Clients_Measurments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Overloads_ClientId",
                table: "Clients_Overloads",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_Images_ParentId",
                table: "Programs_Images",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_Prices_ProgramId",
                table: "Programs_Prices",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_Programs_TrainerId",
                table: "Trainers_Programs",
                column: "TrainerId");
        }
    }
}
