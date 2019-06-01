using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class N13updateTableCongTrinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayLapKeHoach",
                table: "KeHoachXayDung_N13");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "CongTrinh_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaDuAnXayDungCoBan",
                table: "CongTrinh_N13",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "CongTrinh_N13");

            migrationBuilder.DropColumn(
                name: "MaDuAnXayDungCoBan",
                table: "CongTrinh_N13");

            migrationBuilder.AddColumn<string>(
                name: "NgayLapKeHoach",
                table: "KeHoachXayDung_N13",
                nullable: true);
        }
    }
}
