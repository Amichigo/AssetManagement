using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class N13UpdateMatoIDTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaHopDong",
                table: "ThanhToan_N13");

            migrationBuilder.DropColumn(
                name: "MaCongTrinh",
                table: "HoSoThau_N13");

            migrationBuilder.DropColumn(
                name: "MaHoSoThau",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "MaGoiThau",
                table: "DonViThau_N13");

            migrationBuilder.DropColumn(
                name: "MaKeHoach",
                table: "CongTrinh_N13");

            migrationBuilder.AddColumn<int>(
                name: "IdHopDong",
                table: "ThanhToan_N13",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCongTrinh",
                table: "HoSoThau_N13",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdHopDong",
                table: "HoSoThau_N13",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdHoSoThau",
                table: "DonViThau_N13",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idKeHoach",
                table: "CongTrinh_N13",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdHopDong",
                table: "ThanhToan_N13");

            migrationBuilder.DropColumn(
                name: "IdCongTrinh",
                table: "HoSoThau_N13");

            migrationBuilder.DropColumn(
                name: "IdHopDong",
                table: "HoSoThau_N13");

            migrationBuilder.DropColumn(
                name: "IdHoSoThau",
                table: "DonViThau_N13");

            migrationBuilder.DropColumn(
                name: "idKeHoach",
                table: "CongTrinh_N13");

            migrationBuilder.AddColumn<string>(
                name: "MaHopDong",
                table: "ThanhToan_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaCongTrinh",
                table: "HoSoThau_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaHoSoThau",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaGoiThau",
                table: "DonViThau_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaKeHoach",
                table: "CongTrinh_N13",
                nullable: true);
        }
    }
}
