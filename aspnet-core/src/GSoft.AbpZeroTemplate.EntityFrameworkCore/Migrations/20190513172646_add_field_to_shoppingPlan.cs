using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class add_field_to_shoppingPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaKeHoach",
                table: "ShoppingPlans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLanThayDoi",
                table: "ShoppingPlans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TinhTrang",
                table: "ShoppingPlans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaKeHoach",
                table: "ShoppingPlans");

            migrationBuilder.DropColumn(
                name: "SoLanThayDoi",
                table: "ShoppingPlans");

            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "ShoppingPlans");
        }
    }
}
