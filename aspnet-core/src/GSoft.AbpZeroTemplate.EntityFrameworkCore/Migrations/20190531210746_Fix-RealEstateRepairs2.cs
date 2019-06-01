using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class FixRealEstateRepairs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChiPhuSuaChuaThucTe",
                table: "RealEstateRepairs_9",
                newName: "ChiPhiSuaChuaThucTe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChiPhiSuaChuaThucTe",
                table: "RealEstateRepairs_9",
                newName: "ChiPhuSuaChuaThucTe");
        }
    }
}
