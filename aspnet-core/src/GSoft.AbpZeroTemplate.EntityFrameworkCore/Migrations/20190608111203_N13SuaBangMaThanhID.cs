using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class N13SuaBangMaThanhID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaBatDongSan",
                table: "TaiSan_13");

            migrationBuilder.DropColumn(
                name: "MaTaiSan",
                table: "SuaChuaBatDongSan_N13");

            migrationBuilder.DropColumn(
                name: "MaTaiSan",
                table: "BatDongSan_N13");

            migrationBuilder.AddColumn<int>(
                name: "IdBatDongSan",
                table: "TaiSan_13",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTaiSan",
                table: "SuaChuaBatDongSan_N13",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdBatDongSan",
                table: "TaiSan_13");

            migrationBuilder.DropColumn(
                name: "IdTaiSan",
                table: "SuaChuaBatDongSan_N13");

            migrationBuilder.AddColumn<string>(
                name: "MaBatDongSan",
                table: "TaiSan_13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaTaiSan",
                table: "SuaChuaBatDongSan_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaTaiSan",
                table: "BatDongSan_N13",
                nullable: true);
        }
    }
}
