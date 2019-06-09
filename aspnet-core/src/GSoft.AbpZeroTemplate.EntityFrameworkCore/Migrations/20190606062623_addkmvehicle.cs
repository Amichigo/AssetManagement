using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class addkmvehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DinhMucNhienLieu",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoKmDaDi",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DinhMucNhienLieu",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "SoKmDaDi",
                table: "Vehicles");
        }
    }
}
