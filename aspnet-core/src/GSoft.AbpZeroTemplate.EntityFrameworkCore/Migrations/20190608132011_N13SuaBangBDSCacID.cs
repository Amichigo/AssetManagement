using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class N13SuaBangBDSCacID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaLoaiBDS",
                table: "BatDongSan_N13");

            migrationBuilder.DropColumn(
                name: "MaLoaiSoHuu",
                table: "BatDongSan_N13");

            migrationBuilder.AddColumn<int>(
                name: "IdLoaiBDS",
                table: "BatDongSan_N13",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdLoaiSoHuu",
                table: "BatDongSan_N13",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdLoaiBDS",
                table: "BatDongSan_N13");

            migrationBuilder.DropColumn(
                name: "IdLoaiSoHuu",
                table: "BatDongSan_N13");

            migrationBuilder.AddColumn<string>(
                name: "MaLoaiBDS",
                table: "BatDongSan_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaLoaiSoHuu",
                table: "BatDongSan_N13",
                nullable: true);
        }
    }
}
