using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class RentalAsset_N7_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetGroupName",
                table: "RentalAssets");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "RentalAssets");

            migrationBuilder.DropColumn(
                name: "AssetType",
                table: "RentalAssets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssetGroupName",
                table: "RentalAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "RentalAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetType",
                table: "RentalAssets",
                nullable: true);
        }
    }
}
