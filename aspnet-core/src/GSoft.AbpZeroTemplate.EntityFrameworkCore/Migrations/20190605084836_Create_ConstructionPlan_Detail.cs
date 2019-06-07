using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Create_ConstructionPlan_Detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KinhPhiDuocDuyet",
                table: "ConstructionPlanDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KinhPhiTrinh",
                table: "ConstructionPlanDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KinhPhiDuocDuyet",
                table: "ConstructionPlanDetails");

            migrationBuilder.DropColumn(
                name: "KinhPhiTrinh",
                table: "ConstructionPlanDetails");
        }
    }
}
