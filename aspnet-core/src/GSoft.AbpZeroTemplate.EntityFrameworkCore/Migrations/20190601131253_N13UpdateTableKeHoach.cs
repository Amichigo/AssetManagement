using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class N13UpdateTableKeHoach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KinhPhiDuocDuyet",
                table: "KeHoachXayDung_N13",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KinhPhiDuocDuyet",
                table: "KeHoachXayDung_N13");
        }
    }
}
