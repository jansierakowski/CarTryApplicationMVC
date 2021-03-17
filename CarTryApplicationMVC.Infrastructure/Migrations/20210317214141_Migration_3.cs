using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTryApplicationMVC.Infrastructure.Migrations
{
    public partial class Migration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarProductionYear",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarProductionYear",
                table: "Ads",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarProductionYear",
                table: "Ads");

            migrationBuilder.AddColumn<int>(
                name: "CarProductionYear",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
