using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class edit_shoppingPlanDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonVi",
                table: "ShoppingPlanDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GiaTriMotSP",
                table: "ShoppingPlanDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSP",
                table: "ShoppingPlanDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoLuong",
                table: "ShoppingPlanDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongThucHien",
                table: "ShoppingPlanDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TenSP",
                table: "ShoppingPlanDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThangKeHoach",
                table: "ShoppingPlanDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThanhThucHien",
                table: "ShoppingPlanDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonVi",
                table: "ShoppingPlanDetails");

            migrationBuilder.DropColumn(
                name: "GiaTriMotSP",
                table: "ShoppingPlanDetails");

            migrationBuilder.DropColumn(
                name: "MaSP",
                table: "ShoppingPlanDetails");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "ShoppingPlanDetails");

            migrationBuilder.DropColumn(
                name: "SoLuongThucHien",
                table: "ShoppingPlanDetails");

            migrationBuilder.DropColumn(
                name: "TenSP",
                table: "ShoppingPlanDetails");

            migrationBuilder.DropColumn(
                name: "ThangKeHoach",
                table: "ShoppingPlanDetails");

            migrationBuilder.DropColumn(
                name: "ThanhThucHien",
                table: "ShoppingPlanDetails");
        }
    }
}
