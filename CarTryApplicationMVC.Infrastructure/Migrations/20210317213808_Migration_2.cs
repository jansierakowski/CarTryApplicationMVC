using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTryApplicationMVC.Infrastructure.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriveTrain",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NumberOfCylinders",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "OdometerValue",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarDriveTrain",
                table: "Ads",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarFuelType",
                table: "Ads",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarNumberOfCylinders",
                table: "Ads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarOdometerValue",
                table: "Ads",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarDriveTrain",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "CarFuelType",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "CarNumberOfCylinders",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "CarOdometerValue",
                table: "Ads");

            migrationBuilder.AddColumn<string>(
                name: "DriveTrain",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCylinders",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OdometerValue",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
