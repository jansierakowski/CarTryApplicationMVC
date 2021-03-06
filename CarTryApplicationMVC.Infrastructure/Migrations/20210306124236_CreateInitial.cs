using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTryApplicationMVC.Infrastructure.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdName",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdPrice",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdPromotion",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdName",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AdPrice",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AdPromotion",
                table: "Ads");
        }
    }
}
