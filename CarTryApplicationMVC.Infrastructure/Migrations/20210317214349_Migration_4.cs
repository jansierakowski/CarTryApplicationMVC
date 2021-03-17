using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTryApplicationMVC.Infrastructure.Migrations
{
    public partial class Migration_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarLocation",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarLocation",
                table: "Ads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarLocation",
                table: "Ads");

            migrationBuilder.AddColumn<string>(
                name: "CarLocation",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
