using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class fixTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TinhTrangXayDungs",
                table: "TinhTrangXayDungs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TinhTrangSuDungDats",
                table: "TinhTrangSuDungDats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuaChuaBatDongSans",
                table: "SuaChuaBatDongSans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MucDinhSuDungDats",
                table: "MucDinhSuDungDats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiSoHuus",
                table: "LoaiSoHuus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiBatDongSans",
                table: "LoaiBatDongSans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HienTrangPhapLys",
                table: "HienTrangPhapLys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiayPhepSuDungs",
                table: "GiayPhepSuDungs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BatDongSans",
                table: "BatDongSans");

            migrationBuilder.DropColumn(
                name: "NguyenGiaTaiSan",
                table: "BatDongSans");

            migrationBuilder.RenameTable(
                name: "TinhTrangXayDungs",
                newName: "TinhTrangXayDung_N13");

            migrationBuilder.RenameTable(
                name: "TinhTrangSuDungDats",
                newName: "TinhTrangSuDungDat_N13");

            migrationBuilder.RenameTable(
                name: "SuaChuaBatDongSans",
                newName: "SuaChuaBatDongSan_N13");

            migrationBuilder.RenameTable(
                name: "MucDinhSuDungDats",
                newName: "MucDinhSuDungDat_N13");

            migrationBuilder.RenameTable(
                name: "LoaiSoHuus",
                newName: "LoaiSoHuu_N13");

            migrationBuilder.RenameTable(
                name: "LoaiBatDongSans",
                newName: "LoaiBatDongSan_N13");

            migrationBuilder.RenameTable(
                name: "HienTrangPhapLys",
                newName: "HienTrangPhapLy_N13");

            migrationBuilder.RenameTable(
                name: "GiayPhepSuDungs",
                newName: "GiayPhepSuDung_N13");

            migrationBuilder.RenameTable(
                name: "BatDongSans",
                newName: "BatDongSan_N13");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TinhTrangXayDung_N13",
                table: "TinhTrangXayDung_N13",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TinhTrangSuDungDat_N13",
                table: "TinhTrangSuDungDat_N13",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuaChuaBatDongSan_N13",
                table: "SuaChuaBatDongSan_N13",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MucDinhSuDungDat_N13",
                table: "MucDinhSuDungDat_N13",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiSoHuu_N13",
                table: "LoaiSoHuu_N13",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiBatDongSan_N13",
                table: "LoaiBatDongSan_N13",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HienTrangPhapLy_N13",
                table: "HienTrangPhapLy_N13",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiayPhepSuDung_N13",
                table: "GiayPhepSuDung_N13",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BatDongSan_N13",
                table: "BatDongSan_N13",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TinhTrangXayDung_N13",
                table: "TinhTrangXayDung_N13");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TinhTrangSuDungDat_N13",
                table: "TinhTrangSuDungDat_N13");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuaChuaBatDongSan_N13",
                table: "SuaChuaBatDongSan_N13");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MucDinhSuDungDat_N13",
                table: "MucDinhSuDungDat_N13");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiSoHuu_N13",
                table: "LoaiSoHuu_N13");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiBatDongSan_N13",
                table: "LoaiBatDongSan_N13");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HienTrangPhapLy_N13",
                table: "HienTrangPhapLy_N13");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiayPhepSuDung_N13",
                table: "GiayPhepSuDung_N13");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BatDongSan_N13",
                table: "BatDongSan_N13");

            migrationBuilder.RenameTable(
                name: "TinhTrangXayDung_N13",
                newName: "TinhTrangXayDungs");

            migrationBuilder.RenameTable(
                name: "TinhTrangSuDungDat_N13",
                newName: "TinhTrangSuDungDats");

            migrationBuilder.RenameTable(
                name: "SuaChuaBatDongSan_N13",
                newName: "SuaChuaBatDongSans");

            migrationBuilder.RenameTable(
                name: "MucDinhSuDungDat_N13",
                newName: "MucDinhSuDungDats");

            migrationBuilder.RenameTable(
                name: "LoaiSoHuu_N13",
                newName: "LoaiSoHuus");

            migrationBuilder.RenameTable(
                name: "LoaiBatDongSan_N13",
                newName: "LoaiBatDongSans");

            migrationBuilder.RenameTable(
                name: "HienTrangPhapLy_N13",
                newName: "HienTrangPhapLys");

            migrationBuilder.RenameTable(
                name: "GiayPhepSuDung_N13",
                newName: "GiayPhepSuDungs");

            migrationBuilder.RenameTable(
                name: "BatDongSan_N13",
                newName: "BatDongSans");

            migrationBuilder.AddColumn<float>(
                name: "NguyenGiaTaiSan",
                table: "BatDongSans",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TinhTrangXayDungs",
                table: "TinhTrangXayDungs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TinhTrangSuDungDats",
                table: "TinhTrangSuDungDats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuaChuaBatDongSans",
                table: "SuaChuaBatDongSans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MucDinhSuDungDats",
                table: "MucDinhSuDungDats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiSoHuus",
                table: "LoaiSoHuus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiBatDongSans",
                table: "LoaiBatDongSans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HienTrangPhapLys",
                table: "HienTrangPhapLys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiayPhepSuDungs",
                table: "GiayPhepSuDungs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BatDongSans",
                table: "BatDongSans",
                column: "Id");
        }
    }
}
