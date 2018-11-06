using Microsoft.EntityFrameworkCore.Migrations;

namespace Trainer.EF.Migrations
{
    public partial class AddOverallRateToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Products");
        }
    }
}
