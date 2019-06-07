using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class RentalAsset_N7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentalAssetCode",
                table: "RentalAssets",
                newName: "AssetType");

            migrationBuilder.AddColumn<string>(
                name: "AssetCode",
                table: "RentalAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetGroupName",
                table: "RentalAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "RentalAssets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetCode",
                table: "RentalAssets");

            migrationBuilder.DropColumn(
                name: "AssetGroupName",
                table: "RentalAssets");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "RentalAssets");

            migrationBuilder.RenameColumn(
                name: "AssetType",
                table: "RentalAssets",
                newName: "RentalAssetCode");
        }
    }
}
